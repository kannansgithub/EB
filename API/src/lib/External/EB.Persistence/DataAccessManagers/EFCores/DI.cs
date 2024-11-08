using EB.Application.Services.CQS.Commands;
using EB.Application.Services.CQS.Queries;
using EB.Application.Services.Repositories;
using EB.Domain.Repositories;
using EB.Domain.Shared;
using EB.Persistence.DataAccessManagers.EFCores.Contexts;
using EB.Persistence.DataAccessManagers.EFCores.Repositories;
using EB.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;

namespace EB.Persistence.DataAccessManagers.EFCores;

public static class DI
{
    public static IServiceCollection RegisterDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        connectionString = Validator.IsNotNullOrWhiteSpace(connectionString, nameof(connectionString));
        var databaseProvider = configuration["DatabaseProvider"];

        // Register Context
        switch (databaseProvider)
        {
            case "PostgreSql":
                services.AddDbContext<DataContext>(options =>
                    options.UseNpgsql(connectionString)
                    .LogTo(Log.Information, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                );
                services.AddDbContext<CommandContext>(options =>
                    options.UseNpgsql(connectionString)
                    .LogTo(Log.Information, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                );
                services.AddDbContext<QueryContext>(options =>
                    options.UseNpgsql(connectionString)
                    .LogTo(Log.Information, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                );
                break;

            case "MySql":
                services.AddDbContext<DataContext>(options =>
                    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)))
                    .LogTo(Log.Information, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                );
                services.AddDbContext<CommandContext>(options =>
                    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)))
                    .LogTo(Log.Information, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                );
                services.AddDbContext<QueryContext>(options =>
                    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)))
                    .LogTo(Log.Information, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                );
                break;

            case "SqlServer":
            default:
                services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(connectionString)
                    .LogTo(Log.Information, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                );
                services.AddDbContext<CommandContext>(options =>
                    options.UseSqlServer(connectionString)
                    .LogTo(Log.Information, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                );
                services.AddDbContext<QueryContext>(options =>
                    options.UseSqlServer(connectionString)
                    .LogTo(Log.Information, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                );
                break;
        }


        services.AddScoped<ICommandContext, CommandContext>();
        services.AddScoped<IQueryContext, QueryContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IBaseCommandRepository<>), typeof(BaseCommandRepository<>));
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IColorRepository, ColorRepository>();
        services.AddScoped<ICounterRepository, CounterRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IPurchaseItemRepository, PurchaseItemRepository>();
        services.AddScoped<IPurchaseOrderReposirory, PurchaseOrderReposirory>();
        services.AddScoped<IPurchaseReturnRepository, PurchaseReturnRepository>();
        services.AddScoped<ISaleItemRepository, SaleItemRepository>();
        services.AddScoped<ISaleOrderRepository, SaleOrderRepository>();
        services.AddScoped<ISaleReturnRepository, SaleReturnRepository>();
        services.AddScoped<ISizeRepository, SizeRepository>();
        services.AddScoped<IStockRespository, StockRespository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
        services.AddScoped<ITaxRepository, TaxRepository>();
        services.AddScoped<IUomRepository, UomRepository>();
        services.AddScoped<IVendorRepository, VendorRepository>();

        // Register all repositories dynamically
        var repositoryAssembly = Assembly.GetExecutingAssembly();
        var types = repositoryAssembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"))
            .ToList();

        foreach (var implementationType in types)
        {
            var interfaces = implementationType.GetInterfaces()
                .Where(i => i.Name.EndsWith("Repository") && i.IsGenericType == false)
                .ToList();

            foreach (var interfaceType in interfaces)
            {
                services.AddScoped(interfaceType, implementationType);
            }
        }

        return services;
    }

    public static IHost CreateDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;

        // Create database using DataContext
        var dataContext = serviceProvider.GetRequiredService<DataContext>();
        dataContext.Database.EnsureCreated(); // Ensure database is created (development only)

        return host;
    }
}
