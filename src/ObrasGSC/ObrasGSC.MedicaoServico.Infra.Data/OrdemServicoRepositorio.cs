using ObrasGSC.MedicaoServico.Core.Entidades;
using ObrasGSC.MedicaoServico.Core.Repositorios;
using ObrasGSC.MedicaoServico.Infra.Data.Comum;

namespace ObrasGSC.MedicaoServico.Infra.Data
{
    public class OrdemServicoRepositorio : RepositorioBase<OrdemServico>, IOrdemServicoRepositorio
    {
        public override string ContainerName => "OrdemServico";

        public OrdemServicoRepositorio(ICosmosDbContainerFactory factory) : base(factory)
        { }

    }
}
