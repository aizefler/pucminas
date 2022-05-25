using Flurl;
using Flurl.Http;

namespace GSCObras.Data.Services.Comum
{
    public abstract class BaseDataService
    {
        public abstract string ApiPath { get; }
        protected readonly IApimConfigToken ConfigToken;
        protected BaseDataService(IApimConfigToken _configToken)
        {
            ConfigToken = _configToken;
        }

        public async virtual Task<T> GetHttp<T>(string pathSegment, string obraId)
        {
            var accessToken = await ConfigToken.GetAccessToken();
            var results = await ConfigToken.ApimBaseUrl
                            .AppendPathSegment(pathSegment)
                            .SetQueryParam("obraId", obraId)
                            .WithHeader("Content-Type", "application/json")
                            .WithOAuthBearerToken(accessToken)
                            .WithHeader("Ocp-Apim-Subscription-Key", ConfigToken.SubscriptionKey)
                            .GetJsonAsync<T>();
            return results;
        }
    }
}
