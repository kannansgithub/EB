using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class PurchaseReturnRepository(ApplicationDbContext dbContext) : GenericRepository<PurchaseReturn>(dbContext), IPurchaseReturnRepository
{
}
