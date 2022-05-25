using ObrasGSC.MedicaoServico.Core.Entidades;
using ObrasGSC.MedicaoServico.Core.Repositorios;
using ObrasGSC.MedicaoServico.Infra.Data.Comum;

namespace ObrasGSC.MedicaoServico.Infra.Data
{
    public class ServicoRepositorio : RepositorioBase<Servico>, IServicoRepositorio
    {
        public override string ContainerName => "Servico";

        public ServicoRepositorio(ICosmosDbContainerFactory factory) : base(factory)
        { }

    }
}
