using GSCObras.Data.Services.Comum;
using GSCObras.Data.Services.Dtos;

namespace GSCObras.Data.Services
{
    public class ApimGSCObras : BaseDataService, IApimGSCObras
    {
        public override string ApiPath => "medicaoservico";

        public ApimGSCObras(IApimConfigToken configToken) : base(configToken) { }

        public async Task<List<MedicaoPagamentoDto>> MedicaoPagamentoListarAsync(string obraId)
        {
            return await GetHttp<List<MedicaoPagamentoDto>>($"{ApiPath}/Pagamentos", obraId);
        }
    }
}