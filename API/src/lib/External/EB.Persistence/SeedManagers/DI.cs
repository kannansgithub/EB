using EB.Persistence.DataAccessManagers.EFCores.Contexts;
using EB.Persistence.SeedManagers.Demos;
using EB.Persistence.SeedManagers.Systems;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EB.Persistence.SeedManagers;

public static class DI
{
    //>>> System Seed

    public static IServiceCollection RegisterSystemSeedManager(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<RoleClaimSeeder>();
        services.AddScoped<IdentitySeeder>();
        services.AddScoped<CurrencySeeder>();
        services.AddScoped<ConfigSeeder>();
        services.AddScoped<MenuSeeder>();

        return services;
    }


    public static IHost SeedSystemData(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;

        var context = serviceProvider.GetRequiredService<DataContext>();

        if (!context.Config.Any()) //if empty, thats mean never been seeded before
        {

            var roleClaimSeeder = serviceProvider.GetRequiredService<RoleClaimSeeder>();
            roleClaimSeeder.GenerateDataAsync().Wait();

            var identitySeeder = serviceProvider.GetRequiredService<IdentitySeeder>();
            identitySeeder.GenerateDataAsync().Wait();

            var currencySeeder = serviceProvider.GetRequiredService<CurrencySeeder>();
            currencySeeder.GenerateDataAsync().Wait();

            var configSeeder = serviceProvider.GetRequiredService<ConfigSeeder>();
            configSeeder.GenerateDataAsync().Wait();

           
        }
        if (!context.Menu.Any()) //if empty, thats mean never been seeded before
        {
            var menuSeeder = serviceProvider.GetRequiredService<MenuSeeder>();
            menuSeeder.GenerateDataAsync().Wait();
        }
        return host;
    }



    //>>> Demo Seed

    public static IServiceCollection RegisterDemoSeedManager(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<UserSeeder>();


        return services;
    }
    public static IHost SeedDemoData(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;

        var context = serviceProvider.GetRequiredService<DataContext>();
        if (!context.Roles.Any()) //if empty, thats mean never been seeded before
        {
            var userSeeder = serviceProvider.GetRequiredService<UserSeeder>();
            userSeeder.GenerateDataAsync().Wait();
        }
        if (!context.Users.Any()) //if empty, thats mean never been seeded before
        {
            var userSeeder = serviceProvider.GetRequiredService<UserSeeder>();
            userSeeder.GenerateDataAsync().Wait();
        }

        return host;
    }
}
