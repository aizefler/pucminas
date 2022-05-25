namespace GSCObras.Data.Services
{
    public class ApimConfig
    {
        public string SubscriptionKey { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string[] Scopes { get; set; }
        public string ApimBaseUrl { get; set; }
        public string Authority { get; set; }
    }
}
