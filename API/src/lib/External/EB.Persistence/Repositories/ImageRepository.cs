using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class ImageRepository(ApplicationDbContext dbContext) : GenericRepository<Image>(dbContext), IImageRepository
{
}
