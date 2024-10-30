using EB.Domain.Enums;
using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class SaleReturn : Return
{
    public SaleReturn()
    {
        InvoiceNumber = Helper.GetInvoiceNumber(InvoiceType.SALE_RETURN);
    }
    public required string SaleInvoicenumber { get; set; }
    [ForeignKey(nameof(SaleItem))]
    public required string SaleItemId { get; set; }

}
