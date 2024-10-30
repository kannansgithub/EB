using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class ClientRepository(ApplicationDbContext dbContext) : GenericRepository<Client>(dbContext), IClientRepository
{
}
