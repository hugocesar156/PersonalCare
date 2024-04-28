using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalCare.DAL.Repositories;
using PersonalCare.Domain.Interfaces;
using PersonalCare.Domain.Repositories;

namespace PersonalCare.IoC
{
    public static class RepositoriesInjections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoriaTreinoRepository, CategoriaTreinoRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IFichaRepository, FichaRepository>();
            services.AddScoped<IHorarioTreinoContaRepository, HorarioTreinoContaRepository>();
            services.AddScoped<ITreinoRepository, TreinoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
