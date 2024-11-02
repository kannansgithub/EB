using EB.Application.Services.Externals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EB.Infrastructure.DocumentManagers;

public static class DI
{
    public static IServiceCollection RegisterDocumentManager(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DocumentManagerSettings>(configuration.GetSection("DocumentManager"));
        services.AddTransient<IDocumentService, DocumentService>();

        return services;
    }
}
