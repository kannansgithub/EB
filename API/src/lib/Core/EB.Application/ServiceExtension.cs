using EB.Application.Shared.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EB.Application;

public static class ServiceExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ServiceExtension).Assembly;
        
        //>>> AutoMapper
        services.AddAutoMapper(assembly);

        //>>> FluentValidation
        services.AddValidatorsFromAssembly(assembly);

        //>>> MediatR
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(assembly);
            x.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            x.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        return services;
    }
}
