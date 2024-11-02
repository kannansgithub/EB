using EB.Domain.Bases;
using EB.Domain.Enums;
using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class PurchaseOrder : BaseOrder
{
    public PurchaseOrder()
    {
        TransactionType = TransactionType.DEBIT;
        InvoiceNumber = Helper.GetInvoiceNumber(InvoiceType.PURCHASE);
    }
    [ForeignKey(nameof(Vendor))]
    public required string VendorId { get; set; }

    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = [];

}
