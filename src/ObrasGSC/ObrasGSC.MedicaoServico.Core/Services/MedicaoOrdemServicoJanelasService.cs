using GSCObras.MedicaoServico.Core.Entidades;
using GSCObras.MedicaoServico.Core.Repositorios;
using GSCObras.MedicaoServico.Core.ServiceBus;

namespace GSCObras.MedicaoServico.Core.Services
{
    public class MedicaoOrdemServicoJanelasService : IMedicaoOrdemServicoJanelasService
    {
        private readonly IMedicaoOrdemServicoRepositorio _medicaoRepositorio;
        private readonly IObraRepositorio _obraRepositorio;
        private readonly IServiceMessagesBus _serviceMessagesBus;

        public MedicaoOrdemServicoJanelasService(IMedicaoOrdemServicoRepositorio medicaoRepositorio,
            IObraRepositorio obraRepositorio,
            IServiceMessagesBus serviceMessagesBus)
        {
            _medicaoRepositorio = medicaoRepositorio;
            _obraRepositorio = obraRepositorio;
            _serviceMessagesBus = serviceMessagesBus;
        }

        public async Task<MedicaoOrdemServico> Encerrar(string obraId)
        {
            var medicaoAtual = await _medicaoRepositorio.ObterSituacaoAbertoAsync(obraId);

            if (medicaoAtual is not null)
            {
                medicaoAtual.EncerrarJanela();
                await _medicaoRepositorio.ModificarAsync(medicaoAtual.Id, medicaoAtual);
                await NotificarEncerramentoPeriodo(medicaoAtual);
            }

            // ## Inicio - Este código foi adicionado para permitir testes recorrentes
            var medicaoNova = new MedicaoOrdemServico() {
                Id = Guid.NewGuid().ToString(),
                Janela = "03/2022",
                Obra = await _obraRepositorio.ObterAsync(obraId)
            };
            medicaoNova.AbrirJanela();
            await _medicaoRepositorio.AdicionarAsync(medicaoNova);
            // ## Fim

            return medicaoNova;
        }

        private async Task NotificarEncerramentoPeriodo(MedicaoOrdemServico medicaoAtual)
        {
            // Somente para efeitos de testes, pois em cenários reais este recurso seria executado em outro processo em background
            var notifications = new List<NotificationItem>();
            notifications.Add(new NotificationItem()
            {
                Name = "Alexandre Izefler",
                body = $"O período {medicaoAtual.Janela} foi encerrado.",
                EmailTo = "alexandre.izefler@gmail.com",
                Subject = $"Encerramento de Período da Obra {medicaoAtual.Obra.Descricao}"
            });

            await _serviceMessagesBus.Send(notifications, ServiceMessagesBusConstants.TOPIC_NOTIFICATIONS);
        }
    }
}
