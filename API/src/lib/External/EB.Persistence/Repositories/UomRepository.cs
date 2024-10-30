using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class UomRepository(ApplicationDbContext dbContext) : GenericRepository<Uom>(dbContext), IUomRepository
{
}
