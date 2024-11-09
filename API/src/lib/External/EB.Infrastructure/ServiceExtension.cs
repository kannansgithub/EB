using EB.Domain.Repositories;
using EB.Domain.Services;
using EB.Infrastructure.DocumentManagers;
using EB.Infrastructure.EmailManagers;
using EB.Infrastructure.EncryptionManagers;
using EB.Infrastructure.ImageManagers;
using EB.Infrastructure.LoggingManagers.Serilogs;
using EB.Infrastructure.NumberSequenceManagers;
using EB.Infrastructure.Services;
using EB.Persistence;
using EB.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace EB.Infrastructure;

public static class ServiceExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(ServiceExtension).Assembly);
        services.AddPersistence(configuration);
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("RedisConnection");
            options.InstanceName = "EbInstance";
            options.ConfigurationOptions = new ConfigurationOptions()
            {
                AbortOnConnectFail = true,
                EndPoints = { options.Configuration! }
            };
        });

        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IColorService, ColorService>();
        services.AddScoped<ICounterService, CounterService>();
        services.AddScoped<ICustomerService, CustomerService>();
        //services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IPurchaseItemService, PurchaseItemService>();
        services.AddScoped<IPurchaseOrderReposirory, PurchaseOrderReposirory>();
        services.AddScoped<IPurchaseReturnService, PurchaseReturnService>();
        services.AddScoped<ISaleItemService, SaleItemService>();
        services.AddScoped<ISaleOrderService, SaleOrderService>();
        services.AddScoped<ISaleReturnService, SaleReturnService>();
        services.AddScoped<ISizeService, SizeService>();
        services.AddScoped<IStockRespository, StockRespository>();
        services.AddScoped<IStoreService, StoreService>();
        services.AddScoped<ISubCategoryService, SubCategoryService>();
        services.AddScoped<ITaxService, TaxService>();
        services.AddScoped<IUomService, UomService>();
        services.AddScoped<IVendorService, VendorService>();
        //return services;




        //>>> Serilog
        services.RegisterSerilog(configuration);

        //>>> RegisterImageManager
        services.RegisterImageManager(configuration);

        //>>> RegisterDocumentManager
        services.RegisterDocumentManager(configuration);

       

        //>>> NumberSequenceManager
        services.RegisterNumberSequenceManager(configuration);

        //>>> EmailManager
        services.RegisterEmailManager(configuration);

        //>>> EncryptionManager
        services.RegisterEncryptionManager(configuration);

        return services;
    }
}
