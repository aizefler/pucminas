using GSCObras.MedicaoServico.Core.Entidades;
using GSCObras.MedicaoServico.Core.Repositorios;
using GSCObras.MedicaoServico.Infra.Data.Comum;

namespace GSCObras.MedicaoServico.Infra.Data
{
    public class OrdemServicoRepositorio : RepositorioBase<OrdemServico>, IOrdemServicoRepositorio
    {
        public override string ContainerName => "OrdemServico";

        public OrdemServicoRepositorio(ICosmosDbContainerFactory factory) : base(factory)
        { }

    }
}
