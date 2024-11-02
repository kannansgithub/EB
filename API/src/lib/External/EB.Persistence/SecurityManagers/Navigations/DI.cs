using EB.Application.Services.Externals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EB.Persistence.SecurityManagers.Navigations;

public static class DI
{
    public static IServiceCollection RegisterNavigationManager(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<INavigationService, NavigationService>();

        return services;
    }
}
