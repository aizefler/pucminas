using GSCObras.MedicaoServico.Core.Entidades;
using GSCObras.MedicaoServico.Core.Repositorios;
using GSCObras.MedicaoServico.Infra.Data.Comum;

namespace GSCObras.MedicaoServico.Infra.Data
{
    public class MedicaoOrdemServicoRepositorio : RepositorioBase<MedicaoOrdemServico>, IMedicaoOrdemServicoRepositorio
    {
        public override string ContainerName => "MedicaoOrdemServico";

        public MedicaoOrdemServicoRepositorio(ICosmosDbContainerFactory factory) : base(factory)
        { }

    }
}
