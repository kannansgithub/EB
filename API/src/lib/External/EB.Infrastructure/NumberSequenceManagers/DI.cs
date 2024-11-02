using EB.Application.Services.Externals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EB.Infrastructure.NumberSequenceManagers;

public static class DI
{
    public static IServiceCollection RegisterNumberSequenceManager(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<INumberSequenceService, NumberSequenceService>();

        return services;
    }
}
