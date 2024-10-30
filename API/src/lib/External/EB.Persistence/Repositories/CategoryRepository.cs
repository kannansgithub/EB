using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class CategoryRepository(ApplicationDbContext dbContext) : GenericRepository<Category>(dbContext), ICategoryRepository
{
}
