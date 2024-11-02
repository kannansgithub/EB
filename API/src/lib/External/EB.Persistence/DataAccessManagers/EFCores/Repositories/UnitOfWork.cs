using EB.Application.Services.Repositories;
using EB.Domain.Repositories;
using EB.Persistence.DataAccessManagers.EFCores.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace EB.Persistence.DataAccessManagers.EFCores.Repositories;

public class UnitOfWork(
    CommandContext context,
    IAddressRepository addresses,
    ICategoryRepository categories,
    IClientRepository clients,
    IColorRepository colors,
    ICounterRepository counters,
    ICustomerRepository customers,
    IImageRepository images,
    IProductRepository products,
    IPurchaseItemRepository purchaseItems,
    IPurchaseOrderReposirory purchaseOrders,
    IPurchaseReturnRepository purchaseReturns,
    ISaleItemRepository saleItems,
    ISaleOrderRepository saleOrders,
    ISaleReturnRepository saleReturns,
    ISizeRepository sizes,
    IStockRespository stocks,
    IStoreRepository stores,
    ISubCategoryRepository subCategories,
    ITaxRepository taxes,
    IUomRepository uoms,
    IVendorRepository vendors
    ) : IUnitOfWork
{

    private readonly CommandContext _context = context;
    public IAddressRepository Addresses => addresses;
    public ICategoryRepository Categories => categories;
    public IClientRepository Clients => clients;
    public IColorRepository Colors => colors;
    public ICounterRepository Counters => counters;
    public ICustomerRepository Customers => customers;
    public IImageRepository Images => images;
    public IProductRepository Products => products;
    public IPurchaseItemRepository PurchaseItems => purchaseItems;
    public IPurchaseOrderReposirory PurchaseOrders => purchaseOrders;
    public IPurchaseReturnRepository PurchaseReturns => purchaseReturns;
    public ISaleItemRepository SaleItems => saleItems;
    public ISaleOrderRepository SaleOrders => saleOrders;
    public ISaleReturnRepository SaleReturns => saleReturns;
    public ISizeRepository Sizes => sizes;
    public IStockRespository Stocks => stocks;
    public IStoreRepository Stores => stores;
    public ISubCategoryRepository SubCategories => subCategories;
    public ITaxRepository Taxes => taxes;
    public IUomRepository Uoms => uoms;
    public IVendorRepository Vendors => vendors;
    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
    public IDbTransaction BeginTransaction()
    {
        var transaction = _context.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }

   
}
