using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class TaxRepository(ApplicationDbContext dbContext) : GenericRepository<Tax>(dbContext), ITaxRepository
{
}
