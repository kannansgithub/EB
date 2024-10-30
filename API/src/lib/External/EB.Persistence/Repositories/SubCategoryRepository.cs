using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class SubCategoryRepository(ApplicationDbContext dbContext) : GenericRepository<SubCategory>(dbContext), ISubCategoryRepository
{
}
