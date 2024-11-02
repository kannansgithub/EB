using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;
using EB.Persistence.DataAccessManagers.EFCores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.Repositories;

public class CustomerRepository(DataContext dbContext) : GenericRepository<Customer>(dbContext), ICustomerRepository
{
    public async Task<Customer?> GetByContact(string contact)
    {
        return await _dbContext.Customer
                               .Where(c => c.Contact == contact)
                               .Include(i=>i.Addresses)
                               .FirstOrDefaultAsync();
    }
}
