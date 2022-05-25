using ObrasGSC.MedicaoServico.Core.Entidades;
using ObrasGSC.MedicaoServico.Core.Repositorios;
using ObrasGSC.MedicaoServico.Infra.Data.Comum;

namespace ObrasGSC.MedicaoServico.Infra.Data
{
    public class ObraEAPRepositorio : RepositorioBase<ObraEAP>, IObraEAPRepositorio
    {
        public override string ContainerName => "ObraEAP";

        public ObraEAPRepositorio(ICosmosDbContainerFactory factory) : base(factory)
        { }

    }
}
