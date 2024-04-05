﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.UseCases;

namespace PersonalCare.IoC
{
    public static class UseCaseInjections
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IConta, Conta>();

            return services;
        }
    }
}
