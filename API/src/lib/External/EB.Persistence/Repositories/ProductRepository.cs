using EB.Domain.Abstrations;
using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.Repositories;

public class ProductRepository(ApplicationDbContext dbContext) : GenericRepository<Product>(dbContext), IProductRepository
{
    public async Task<IEnumerable<ProductDetail>?> GetByCategory(string categoryId, CancellationToken cancellationToken = default)
    {
        var products =await (from p in _dbContext.Products.AsQueryable()
                        join s in _dbContext.Stocks.AsQueryable() on p.StockId equals s.Id
                        join u in _dbContext.Uoms.AsQueryable() on p.UOMId equals u.Id
                        join sub in _dbContext.SubCategories.AsQueryable() on p.SubCategoryId equals sub.Id
                        join ca in _dbContext.Categories.AsQueryable() on sub.CategoryId equals ca.Id
                        where ca.Id == categoryId
                        select new ProductDetail
                        (
                            p.Id,
                            p.Name,
                            p.Description,
                            p.Sku,
                            p.MRP,
                            p.Price,
                            p.Amount,
                            p.ExpaireDate,
                            p.MinOrderQty,
                            p.MaxOrderQty,
                            GetTaxName(p.CGSTId),
                            GetTaxName(p.SGSTId),
                            GetTaxName(p.IGSTId),
                            u.Name,
                            u.Symbol,
                            s.CurrentStock,
                            s.LastSale,
                            ca.Name,
                            ca.Description,
                            sub.Name,
                            sub.Description
                        )).ToListAsync(cancellationToken);
        return products;
    }
    
    public async Task<ProductDetail?> GetBySku(string sku, CancellationToken cancellationToken = default)
    {
        var product = await(from p in _dbContext.Products.AsQueryable()
                             join s in _dbContext.Stocks.AsQueryable() on p.StockId equals s.Id
                             join u in _dbContext.Uoms.AsQueryable() on p.UOMId equals u.Id
                             join sub in _dbContext.SubCategories.AsQueryable() on p.SubCategoryId equals sub.Id
                             join ca in _dbContext.Categories.AsQueryable() on sub.CategoryId equals ca.Id
                             where p.Sku == sku
                             select new ProductDetail
                             (
                                 p.Id,
                                 p.Name,
                                 p.Description,
                                 p.Sku,
                                 p.MRP,
                                 p.Price,
                                 p.Amount,
                                 p.ExpaireDate,
                                 p.MinOrderQty,
                                 p.MaxOrderQty,
                                 GetTaxName(p.CGSTId),
                                 GetTaxName(p.SGSTId),
                                 GetTaxName(p.IGSTId),
                                 u.Name,
                                 u.Symbol,
                                 s.CurrentStock,
                                 s.LastSale,
                                 ca.Name,
                                 ca.Description,
                                 sub.Name,
                                 sub.Description
                             )).FirstOrDefaultAsync(cancellationToken);
        return product;
    }
    private string GetTaxName(string taxId)
    {
        var tax = _dbContext.Taxes.FirstOrDefault(x => x.Id == taxId);
        return tax?.Name ?? string.Empty;
    }
}
