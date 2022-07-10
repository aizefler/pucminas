using GSCObras.Data.Services.Dtos;

namespace GSCObras.Data.Services
{
    public interface IApimGSCObras
    {
        Task<List<MedicaoPagamentoDto>> MedicaoPagamentoListarAsync(string obraId);
        Task<List<ObrasDto>> ObrasListarAsync();
    }
}