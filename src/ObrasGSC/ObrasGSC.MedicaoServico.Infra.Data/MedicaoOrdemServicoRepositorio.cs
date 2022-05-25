using ObrasGSC.MedicaoServico.Core.Entidades;
using ObrasGSC.MedicaoServico.Core.Repositorios;
using ObrasGSC.MedicaoServico.Infra.Data.Comum;

namespace ObrasGSC.MedicaoServico.Infra.Data
{
    public class MedicaoOrdemServicoRepositorio : RepositorioBase<MedicaoOrdemServico>, IMedicaoOrdemServicoRepositorio
    {
        public override string ContainerName => "MedicaoOrdemServico";

        public MedicaoOrdemServicoRepositorio(ICosmosDbContainerFactory factory) : base(factory)
        { }

    }
}
