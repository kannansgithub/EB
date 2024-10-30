using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class CounterRepository(ApplicationDbContext dbContext) : GenericRepository<Counter>(dbContext), ICounterRepository
{
}
