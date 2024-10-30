using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EB.Application;

public static class ServiceExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ServiceExtension).Assembly;
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
