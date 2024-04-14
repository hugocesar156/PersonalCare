using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PersonalCare.DAL.Context;
using Microsoft.AspNetCore.Http;

namespace PersonalCare.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContextAcesso>(options => options.UseSqlServer(configuration.GetConnectionString("PersonalCareAcesso") ?? string.Empty), ServiceLifetime.Transient);
            services.AddDbContext<DataContextBase>(options => options.UseSqlServer(configuration.GetConnectionString("PersonalCareBase") ?? string.Empty), ServiceLifetime.Transient);
            services.AddDbContext<DataContextEmpresarial>(options => options.UseSqlServer(configuration.GetConnectionString("PersonalCareEmpresarial") ?? string.Empty), ServiceLifetime.Transient);

            services.AddUseCases(configuration);
            services.AddRepositories(configuration);
            
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}