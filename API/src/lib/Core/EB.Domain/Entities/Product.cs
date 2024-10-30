using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class Product:AuditableEntity
{
    public required string Sku { get;  set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal MRP { get; set; } = 0.0M;
    //Purchase Price
    public decimal Price { get; set; } = 0.0M;
    //Sale Price
    public decimal Amount { get; set; } = 0.0M;
    public DateOnly ExpaireDate { get; set; }
    public int MinOrderQty { get; set; } = 1;
    public int MaxOrderQty { get; set; } = 100;
    [ForeignKey(nameof(SubCategory))]
    public required string SubCategoryId { get; set; }
    public required string CGSTId { get; set; }

    public required string SGSTId { get; set; }

    public required string IGSTId { get; set; }
    public required string UOMId { get; set; }
    public required string StockId { get; set; }
    public required string StoreId { get; set; }

    public required virtual Uom Uom { get; set; }
    public required virtual Stock Stock { get; set; }
    public required virtual Store Store { get; set; }


    public virtual ICollection<Color> Colors { get; set; } = [];
    public virtual ICollection<Size> Sizes { get; set; } = [];
    public virtual ICollection<Image> Images { get; set; } = [];

}
