using GSCObras.MedicaoServico.Core.Entidades;

namespace GSCObras.MedicaoServico.Core.Repositorios
{
    public interface IRepositorioBase<T> where T : EntidadeBase
    {
        Task<bool> ExisteAsync(string id);
        Task<T> ObterAsync(string id);
        Task AdicionarAsync(T item);
        Task ModificarAsync(string id, T item);
        Task RemoverAsync(string id);
    }
}