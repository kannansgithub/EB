using EB.Persistence.DataAccessManagers.EFCores;
using EB.Persistence.SecurityManagers.AspNetIdentity;
using EB.Persistence.SecurityManagers.Navigations;
using EB.Persistence.SecurityManagers.RoleClaims;
using EB.Persistence.SecurityManagers.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace EB.Persistence;
public static class ServiceExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        //return services;
        //>>> DataAccess
        services.RegisterDataAccess(configuration);

        //>>> AspNetIdentity
        services.RegisterAspNetIdentity(configuration);

        //>>> Policy
        services.RegisterPolicy(configuration);
        //>>> RegisterToken
        services.RegisterToken(configuration);

        //>>> NavigationManager
        services.RegisterNavigationManager(configuration);

        return services;
    }
}
