using EB.Application.Services.Externals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EB.Persistence.SecurityManagers.RoleClaims;
public static class DI
{
    public static IServiceCollection RegisterPolicy(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRoleClaimService, RoleClaimService>();
        return services;
    }

}