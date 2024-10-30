using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class ColorRepository(ApplicationDbContext dbContext) : GenericRepository<Color>(dbContext), IColorRepository
{
}
