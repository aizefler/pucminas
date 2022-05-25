using Microsoft.Azure.Cosmos;
using ObrasGSC.MedicaoServico.Core.Entidades;
using ObrasGSC.MedicaoServico.Core.Repositorios;
using ObrasGSC.MedicaoServico.Infra.Data.Comum;

namespace ObrasGSC.MedicaoServico.Infra.Data
{
    public class MedicaoOrdemServicoPagamentoRepositorio : RepositorioBase<MedicaoOrdemServicoPagamento>, IMedicaoOrdemServicoPagamentoRepositorio
    {
        public override string ContainerName => "MedicaoOrdemServicoPagamento";

        public MedicaoOrdemServicoPagamentoRepositorio(ICosmosDbContainerFactory factory) : base(factory)
        { }

        public Task<IEnumerable<MedicaoOrdemServicoPagamento>> ListarAsync(string obraId)
        {
            var query = new QueryDefinition("SELECT * FROM MedicaoOrdemServicoPagamento P WHERE P.ObraId=@obraId")
                                           .WithParameter("@obraId", obraId);
            return ConsultarAsync(query);
        }
    }
}
