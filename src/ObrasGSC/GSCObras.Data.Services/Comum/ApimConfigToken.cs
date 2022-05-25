using GSCObras.Data.Services;
using Microsoft.Identity.Client;

namespace GSCObras.Data.Services.Comum
{
    public class ApimConfigToken : IApimConfigToken
    {
        private IConfidentialClientApplication _app;
        private readonly ApimConfig _config;

        public string SubscriptionKey => _config.SubscriptionKey;
        public string ApimBaseUrl => _config.ApimBaseUrl;

        public ApimConfigToken(ApimConfig config)
        {
            _config = config;
            PrepareConfidentialClient();
        }

        public async Task<string> GetAccessToken()
        {
            var result = await _app.AcquireTokenForClient(_config.Scopes)
                .ExecuteAsync();
            return result.AccessToken;
        }

        private void PrepareConfidentialClient()
        {

            _app = ConfidentialClientApplicationBuilder.Create(_config.ClientId)
                .WithClientSecret(_config.ClientSecret)
                .WithAuthority(new Uri(_config.Authority))
                .WithClientCapabilities(new[] { "cp1" })
                .Build();

        }
    }
}
