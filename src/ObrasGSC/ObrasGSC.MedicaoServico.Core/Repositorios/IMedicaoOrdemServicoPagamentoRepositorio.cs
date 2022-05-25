using GSCObras.MedicaoServico.Core.Entidades;

namespace GSCObras.MedicaoServico.Core.Repositorios
{
    public interface IMedicaoOrdemServicoPagamentoRepositorio : IRepositorioBase<MedicaoOrdemServicoPagamento>
    {
        Task<IEnumerable<MedicaoOrdemServicoPagamento>> ListarAsync(string obraId);
    }
}
