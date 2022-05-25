using ObrasGSC.MedicaoServico.Core.Entidades;

namespace ObrasGSC.MedicaoServico.Core.Repositorios
{
    public interface IMedicaoOrdemServicoPagamentoRepositorio : IRepositorioBase<MedicaoOrdemServicoPagamento>
    {
        Task<IEnumerable<MedicaoOrdemServicoPagamento>> ListarAsync(string obraId);
    }
}
