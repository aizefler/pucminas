using Flurl;
using Flurl.Http;
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
            return await GetHttp<List<MedicaoPagamentoDto>>($"{ApiPath}/Pagamentos", new { obraId = obraId });
        }

        public async Task<List<ObrasDto>> ObrasListarAsync()
        {
            return await GetHttp<List<ObrasDto>>($"{ApiPath}/Obras");
        }
        public async Task<MedicaoServicoEncerrarDto> MedicaoServicoEncerrarAsync(string obraId)
        {
            var accessToken = await ConfigToken.GetAccessToken();
            var results = await ConfigToken.ApimBaseUrl
                            .AppendPathSegment($"{ApiPath}/{obraId}/encerrar")
                            .WithHeader("Accept", "*/*")
                            .WithOAuthBearerToken(accessToken)
                            .WithHeader("Ocp-Apim-Subscription-Key", ConfigToken.SubscriptionKey)
                            .PostAsync();
            return await results.GetJsonAsync<MedicaoServicoEncerrarDto>();
        }
    }
}