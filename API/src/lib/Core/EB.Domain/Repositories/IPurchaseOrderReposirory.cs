using EB.Domain.Entities;
using EB.Domain.Interfaces;

namespace EB.Domain.Repositories;

public interface IPurchaseOrderReposirory : IGenericRepository<PurchaseOrder>
{
    Task<PurchaseOrder?> GetByInvoiceNumber(string invoiceNumber);

}
