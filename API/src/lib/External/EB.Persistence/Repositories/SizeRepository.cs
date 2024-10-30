using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class SizeRepository(ApplicationDbContext dbContext) : GenericRepository<Size>(dbContext), ISizeRepository
{
}
