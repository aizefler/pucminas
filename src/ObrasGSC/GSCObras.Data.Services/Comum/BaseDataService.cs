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

        public async virtual Task<T> GetHttp<T>(string pathSegment)
        {
            var accessToken = await ConfigToken.GetAccessToken();
            var results = await ConfigToken.ApimBaseUrl
                            .AppendPathSegment(pathSegment)
                            .WithHeader("Content-Type", "application/json")
                            .SetQueryParams()
                            .WithOAuthBearerToken(accessToken)
                            .WithHeader("Ocp-Apim-Subscription-Key", ConfigToken.SubscriptionKey)
                            .GetJsonAsync<T>();
            return results;
        }

        public async virtual Task<T> GetHttp<T>(string pathSegment, object parameters)
        {
            var accessToken = await ConfigToken.GetAccessToken();
            var results = await ConfigToken.ApimBaseUrl
                            .AppendPathSegment(pathSegment)
                            .SetQueryParams(parameters)
                            .WithHeader("Content-Type", "application/json")
                            .WithOAuthBearerToken(accessToken)
                            .WithHeader("Ocp-Apim-Subscription-Key", ConfigToken.SubscriptionKey)
                            .GetJsonAsync<T>();
            return results;
        }
    }
}
