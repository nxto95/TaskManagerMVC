using System;
using DAL.Repository.Implementations;
using DAL.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDal(this IServiceCollection services)
    {
        services.AddScoped<IUserModelRepo, UserModelRepo>();
        return services;
    }
}
