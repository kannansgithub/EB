using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;
using EB.Persistence.DataAccessManagers.EFCores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.Repositories;

public class VendorRepository(DataContext dbContext) : GenericRepository<Vendor>(dbContext), IVendorRepository
{
    public async Task<Vendor?> GetByContact(string contact)
    {
        return await _dbContext.Vendor
                                .Where(c => c.PrimaryContact == contact)
                                .Include(i => i.Addresses)
                                .FirstOrDefaultAsync();
    }
}
