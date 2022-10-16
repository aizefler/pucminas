using GSCObras.MedicaoServico.Core.Entidades;

namespace GSCObras.MedicaoServico.Core.Services
{
    public interface IMedicaoOrdemServicoJanelasService
    {
        Task<MedicaoOrdemServico> Encerrar(MedicaoOrdemServico medicao);
    }
}
