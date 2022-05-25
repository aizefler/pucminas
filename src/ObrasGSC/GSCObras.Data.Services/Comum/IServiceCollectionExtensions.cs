using GSCObras.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GSCObras.Data.Services.Comum
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApim(this IServiceCollection services,
                                                     ApimConfig config)
        {
            var apimToken = new ApimConfigToken(config);
            services.AddSingleton<IApimConfigToken>(apimToken);
            return services;
        }
    }
}
