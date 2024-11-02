using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;
using EB.Persistence.DataAccessManagers.EFCores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.Repositories;

public class SaleOrderRepository(DataContext dbContext) : GenericRepository<SaleOrder>(dbContext), ISaleOrderRepository
{
    public async Task<SaleOrder?> GetByInvoiceNumber(string invoiceNumber)
    {
        return await _dbContext.SaleOrder.Where(c => c.InvoiceNumber == invoiceNumber)
                                              .Include(i => i.SaleItems)
                                              .FirstOrDefaultAsync();
    }
}
