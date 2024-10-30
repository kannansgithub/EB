using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.Repositories;

public class PurchaseOrderReposirory(ApplicationDbContext dbContext) : GenericRepository<PurchaseOrder>(dbContext), IPurchaseOrderReposirory
{
    public async Task<PurchaseOrder?> GetByInvoiceNumber(string invoiceNumber)
    {
        return await _dbContext.PurchaseOrders.Where(c => c.InvoiceNumber == invoiceNumber)
                                              .Include(i=>i.PurchaseItems)
                                              .FirstOrDefaultAsync();

    }
}
