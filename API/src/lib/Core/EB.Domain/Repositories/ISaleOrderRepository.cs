using EB.Domain.Entities;
using EB.Domain.Interfaces;

namespace EB.Domain.Repositories;

public interface ISaleOrderRepository: IGenericRepository<SaleOrder>
{
    Task<SaleOrder?> GetByInvoiceNumber(string invoiceNumber);

}
