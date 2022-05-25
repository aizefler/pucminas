using Microsoft.Azure.Cosmos;
using ObrasGSC.MedicaoServico.Core.Entidades;
using ObrasGSC.MedicaoServico.Core.Repositorios;
using ObrasGSC.MedicaoServico.Infra.Data.Comum;

namespace ObrasGSC.MedicaoServico.Infra.Data
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
