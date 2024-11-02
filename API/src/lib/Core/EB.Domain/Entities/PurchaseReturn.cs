using EB.Domain.Bases;
using EB.Domain.Enums;
using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class PurchaseReturn:BaseReturn
{
    public PurchaseReturn()
    {
        InvoiceNumber = Helper.GetInvoiceNumber(InvoiceType.PURCHASE_RETURN);
    }
    public required string PurchaseInvoicenumber { get; set; }
    [ForeignKey(nameof(PurchaseItem))]
    public required string PurchaseItemId { get; set; }

}
