using GSCObras.MedicaoServico.Core.Entidades;

namespace GSCObras.MedicaoServico.Core.Repositorios
{
    public interface IMedicaoOrdemServicoRepositorio : IRepositorioBase<MedicaoOrdemServico>
    {
        Task<MedicaoOrdemServico> ObterSituacaoAbertoAsync(string obraId);
    }
}
