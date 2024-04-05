using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalCare.Domain.Interfaces;
using PersonalCare.Domain.Repositories;

namespace PersonalCare.IoC
{
    public static class RepositoriesInjections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IContaRepository, ContaRepository>();
         
            return services;
        }
    }
}
