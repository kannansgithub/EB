using System.ComponentModel.DataAnnotations.Schema;
using EB.Domain.Bases;

namespace EB.Domain.Entities;

public class SaleItem:BaseOrderItem
{
    [ForeignKey(nameof(SaleOrder))]
    public required string SaleOrderId { get; set; }


}
