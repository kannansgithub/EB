using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class PurchaseItemRepository(ApplicationDbContext dbContext) : GenericRepository<PurchaseItem>(dbContext), IPurchaseItemRepository
{
}
