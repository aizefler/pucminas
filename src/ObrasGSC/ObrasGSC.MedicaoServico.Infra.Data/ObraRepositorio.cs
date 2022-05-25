using Microsoft.Azure.Cosmos;
using GSCObras.MedicaoServico.Core.Entidades;
using GSCObras.MedicaoServico.Core.Repositorios;
using GSCObras.MedicaoServico.Infra.Data.Comum;

namespace GSCObras.MedicaoServico.Infra.Data
{
    public class ObraRepositorio : RepositorioBase<Obra>, IObraRepositorio
    {
        public override string ContainerName => "Obra";

        public ObraRepositorio(ICosmosDbContainerFactory factory) : base(factory)
        { }

        public Task<IEnumerable<Obra>> ListarAsync()
        {
            return ConsultarAsync(new 
                QueryDefinition("SELECT * FROM Obra"));
        }
    }
}
