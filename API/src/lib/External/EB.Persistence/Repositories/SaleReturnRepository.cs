using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class SaleReturnRepository(ApplicationDbContext dbContext) : GenericRepository<SaleReturn>(dbContext), ISaleReturnRepository
{
}
