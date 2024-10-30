using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;

namespace EB.Persistence.Repositories;

public class AddressRepository(ApplicationDbContext dbContext) : GenericRepository<Address>(dbContext), IAddressRepository
{
}
