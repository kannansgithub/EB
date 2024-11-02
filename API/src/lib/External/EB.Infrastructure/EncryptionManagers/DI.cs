using EB.Application.Services.Externals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EB.Infrastructure.EncryptionManagers;


public static class DI
{
    public static IServiceCollection RegisterEncryptionManager(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IEncryptionService, EncryptionService>();

        return services;
    }
}
