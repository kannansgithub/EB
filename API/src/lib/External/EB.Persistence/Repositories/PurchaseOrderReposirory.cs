using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;
using EB.Persistence.DataAccessManagers.EFCores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.Repositories;

public class PurchaseOrderReposirory(DataContext dbContext) : GenericRepository<PurchaseOrder>(dbContext), IPurchaseOrderReposirory
{
    public async Task<PurchaseOrder?> GetByInvoiceNumber(string invoiceNumber)
    {
        return await _dbContext.PurchaseOrder.Where(c => c.InvoiceNumber == invoiceNumber)
                                              .Include(i=>i.PurchaseItems)
                                              .FirstOrDefaultAsync();

    }
}
