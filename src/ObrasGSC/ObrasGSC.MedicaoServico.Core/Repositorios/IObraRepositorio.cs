using ObrasGSC.MedicaoServico.Core.Entidades;

namespace ObrasGSC.MedicaoServico.Core.Repositorios
{
    public interface IObraRepositorio : IRepositorioBase<Obra>
    {
        Task<IEnumerable<Obra>> ListarAsync();
    }
}
