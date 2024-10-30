using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class SaleItem:OrderItem
{
    [ForeignKey(nameof(SaleOrder))]
    public required string SaleOrderId { get; set; }


}
