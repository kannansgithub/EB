using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class PurchaseItem:OrderItem
{
    [ForeignKey(nameof(PurchaseOrder))]
    public required string PurchaseOrderId { get; set; }

}
