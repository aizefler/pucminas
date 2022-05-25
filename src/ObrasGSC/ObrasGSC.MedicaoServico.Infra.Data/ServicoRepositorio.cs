using GSCObras.MedicaoServico.Core.Entidades;
using GSCObras.MedicaoServico.Core.Repositorios;
using GSCObras.MedicaoServico.Infra.Data.Comum;

namespace GSCObras.MedicaoServico.Infra.Data
{
    public class ServicoRepositorio : RepositorioBase<Servico>, IServicoRepositorio
    {
        public override string ContainerName => "Servico";

        public ServicoRepositorio(ICosmosDbContainerFactory factory) : base(factory)
        { }

    }
}
