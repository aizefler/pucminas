using GSCObras.MedicaoServico.Core.Entidades;
using GSCObras.MedicaoServico.Core.Repositorios;
using GSCObras.MedicaoServico.Infra.Data.Comum;

namespace GSCObras.MedicaoServico.Infra.Data
{
    public class ObraEAPRepositorio : RepositorioBase<ObraEAP>, IObraEAPRepositorio
    {
        public override string ContainerName => "ObraEAP";

        public ObraEAPRepositorio(ICosmosDbContainerFactory factory) : base(factory)
        { }

    }
}
