namespace GSCObras.Data.Services.Comum
{
    public interface IApimConfigToken
    {
        public string SubscriptionKey { get; }
        public string ApimBaseUrl { get; }
        Task<string> GetAccessToken();
    }
}
