using System.ComponentModel.DataAnnotations.Schema;
using EB.Domain.Bases;

namespace EB.Domain.Entities;

public class PurchaseItem : BaseOrderItem
{
    [ForeignKey(nameof(PurchaseOrder))]
    public required string PurchaseOrderId { get; set; }

}
