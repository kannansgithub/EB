using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.Repositories;

public class VendorRepository(ApplicationDbContext dbContext) : GenericRepository<Vendor>(dbContext), IVendorRepository
{
    public async Task<Vendor?> GetByContact(string contact)
    {
        return await _dbContext.Vendors
                                .Where(c => c.PrimaryContact == contact)
                                .Include(i => i.Addresses)
                                .FirstOrDefaultAsync();
    }
}
