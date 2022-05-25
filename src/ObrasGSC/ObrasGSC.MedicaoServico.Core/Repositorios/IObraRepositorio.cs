using GSCObras.MedicaoServico.Core.Entidades;

namespace GSCObras.MedicaoServico.Core.Repositorios
{
    public interface IObraRepositorio : IRepositorioBase<Obra>
    {
        Task<IEnumerable<Obra>> ListarAsync();
    }
}
