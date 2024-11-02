using EB.Application.Services.Externals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EB.Infrastructure.ImageManagers;

public static class DI
{
    public static IServiceCollection RegisterImageManager(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ImageManagerSettings>(configuration.GetSection("ImageManager"));
        services.AddTransient<IImageService, ImageService>();

        return services;
    }
}
