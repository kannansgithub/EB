using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class StoreRepository(ApplicationDbContext dbContext) : GenericRepository<Store>(dbContext), IStoreRepository
{
}
