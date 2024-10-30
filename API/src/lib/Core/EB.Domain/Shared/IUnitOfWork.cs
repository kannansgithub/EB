using EB.Domain.Repositories;
using System.Data;

namespace EB.Domain.Shared;

public interface IUnitOfWork : IDisposable
{
    IAddressRepository Addresses  { get; }
    ICategoryRepository Categories { get; }
    IClientRepository Clients { get; }
    IColorRepository Colors { get; }
    ICounterRepository Counters { get; }
    ICustomerRepository Customers { get; }
    IImageRepository Images { get; }
    IProductRepository Products { get; }
    IPurchaseItemRepository PurchaseItems { get; }
    IPurchaseOrderReposirory PurchaseOrders { get; }
    IPurchaseReturnRepository PurchaseReturns { get; }
    ISaleItemRepository SaleItems { get; }
    ISaleOrderRepository SaleOrders { get; }
    ISaleReturnRepository SaleReturns { get; }
    ISizeRepository Sizes { get; }
    IStockRespository Stocks { get; }
    IStoreRepository Stores { get; }
    ISubCategoryRepository SubCategories { get; }
    ITaxRepository Taxes { get; }
    IUomRepository Uoms { get; }
    IVendorRepository Vendors { get; }

    IDbTransaction BeginTransaction();
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
