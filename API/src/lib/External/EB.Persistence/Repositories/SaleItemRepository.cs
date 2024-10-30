using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class SaleItemRepository(ApplicationDbContext dbContext) : GenericRepository<SaleItem>(dbContext), ISaleItemRepository
{
}
