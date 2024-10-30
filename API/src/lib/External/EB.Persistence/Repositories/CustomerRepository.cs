using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.Repositories;

public class CustomerRepository(ApplicationDbContext dbContext) : GenericRepository<Customer>(dbContext), ICustomerRepository
{
    public async Task<Customer?> GetByContact(string contact)
    {
        return await _dbContext.Customers
                               .Where(c => c.Contact == contact)
                               .Include(i=>i.Addresses)
                               .FirstOrDefaultAsync();
    }
}
