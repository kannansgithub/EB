using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.Repositories;

public class SaleOrderRepository(ApplicationDbContext dbContext) : GenericRepository<SaleOrder>(dbContext), ISaleOrderRepository
{
    public async Task<SaleOrder?> GetByInvoiceNumber(string invoiceNumber)
    {
        return await _dbContext.SaleOrders.Where(c => c.InvoiceNumber == invoiceNumber)
                                              .Include(i => i.SaleItems)
                                              .FirstOrDefaultAsync();
    }
}
