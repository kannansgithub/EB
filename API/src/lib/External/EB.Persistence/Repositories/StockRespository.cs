using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class StockRespository(ApplicationDbContext dbContext) : GenericRepository<Stock>(dbContext), IStockRespository
{
}
