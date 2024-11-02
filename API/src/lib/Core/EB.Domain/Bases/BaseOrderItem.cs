using EB.Domain.Entities;
using EB.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Bases;

public class BaseOrderItem : BaseEntityCommon, IAggregateRoot
{
    public BaseOrderItem()
    {
        Amount = Quantity * Price;
    }
    [ForeignKey(nameof(Product))]
    public required string ProductId { get; set; }
    public required string ProductName { get; set; }
    public required string ProductDescription { get; set; }
    public required string Sku { get; set; }
    public decimal MRP { get; set; } = 0.0M;
    public decimal Price { get; set; } = 0.0M;
    public decimal Amount { get; set; } = 0.0M;
    public int Quantity { get; set; } = 0;
    public decimal CGST { get; set; } = 0.0M;
    public decimal SGST { get; set; } = 0.0M;
    public decimal IGST { get; set; } = 0.0M;

}
