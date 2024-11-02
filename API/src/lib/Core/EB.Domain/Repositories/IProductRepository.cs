using EB.Domain.Abstrations;
using EB.Domain.Entities;
using EB.Domain.Interfaces;

namespace EB.Domain.Repositories;

public interface IProductRepository: IGenericRepository<Product>
{
    Task<ProductDetail?> GetBySku(string sku, CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductDetail>?> GetByCategory(string categoryId, CancellationToken cancellationToken = default);
}
