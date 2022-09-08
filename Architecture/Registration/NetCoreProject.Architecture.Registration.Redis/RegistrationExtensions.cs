using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreProject.Architecture.Data.Cache.Interfaces;
using NetCoreProject.Architecture.Data.Cache.Redis;
using StackExchange.Redis;

namespace NetCoreProject.Architecture.Registration.Redis
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddRedisRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(action =>
                action.Configuration = configuration["Redis:ConnectionString"]
            );

            services.AddSingleton<IConnectionMultiplexer>(
               ConnectionMultiplexer.Connect(configuration["Redis:ConnectionString"])
            );

            services.AddScoped<ICacheService, RedisCacheService>();

            return services;
        }
    }
}
