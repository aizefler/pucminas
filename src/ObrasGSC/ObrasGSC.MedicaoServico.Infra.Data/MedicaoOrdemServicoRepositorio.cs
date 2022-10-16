using GSCObras.MedicaoServico.Core.Entidades;
using GSCObras.MedicaoServico.Core.Repositorios;
using GSCObras.MedicaoServico.Infra.Data.Comum;
using Microsoft.Azure.Cosmos;

namespace GSCObras.MedicaoServico.Infra.Data
{
    public class MedicaoOrdemServicoRepositorio : RepositorioBase<MedicaoOrdemServico>, IMedicaoOrdemServicoRepositorio
    {
        public override string ContainerName => "MedicaoOrdemServico";

        public MedicaoOrdemServicoRepositorio(ICosmosDbContainerFactory factory) : base(factory)
        { }

        public async Task<MedicaoOrdemServico> ObterSituacaoAbertoAsync(string obraId)
        {
            var query = new QueryDefinition(
                "SELECT * FROM MedicaoOrdemServico as M Where M.Situacao = 'ABERTO' and M.Obra.id = @obraId")
                .WithParameter("@obraId", obraId);
            var resultado = await this.ConsultarAsync(query);

            return resultado.FirstOrDefault();
        }

    }
}
