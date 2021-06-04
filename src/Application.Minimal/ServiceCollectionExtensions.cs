using Application.Domain;
using Application.Minimal.Endpoints;
using Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Minimal
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEndpoints(this IServiceCollection services)
        {
            services.AddTransient<ValidationEndpoint>();
            return services;
        }

        public static IServiceCollection AddDomainLogic(this IServiceCollection services)
        {
            services.AddTransient<ValidationInteractor>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IGetMaximumQuery, GetMaximumQuery>();
            return services;
        }
    }
}
