using EB.Domain.Bases;
using EB.Domain.Enums;
using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class SaleOrder:BaseOrder
{
    public SaleOrder()
    {
        TransactionType = TransactionType.CREDIT;
        InvoiceNumber = Helper.GetInvoiceNumber(InvoiceType.SALE);
    }
    [ForeignKey(nameof(Customer))]
    public required string CustomerId { get; set; }

    public virtual ICollection<SaleItem> SaleItems { get; set; } = [];
}
