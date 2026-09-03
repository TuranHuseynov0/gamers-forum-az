using GamingCommunity.Application.Services.Implementations;
using GamingCommunity.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GamingCommunity.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}