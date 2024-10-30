using EB.Domain.Repositories;
using EB.Domain.Shared;
using EB.Persistence.Abstrations;
using EB.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace EB.Persistence;
public static class ServiceExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        //services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IColorRepository, ColorRepository>();
        services.AddScoped<ICounterRepository, CounterRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
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
        return services;
    }
}
