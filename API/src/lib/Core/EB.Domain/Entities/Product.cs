using EB.Domain.Bases;
using EB.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class Product: BaseEntityAdvance, IAggregateRoot
{
    public string Sku { get; set; } = null!;

    public decimal MRP { get; set; } = 0.0M;
    //Purchase Price
    public decimal Price { get; set; } = 0.0M;
    //Sale Price
    public decimal Amount { get; set; } = 0.0M;
    public DateOnly ExpaireDate { get; set; }
    public int MinOrderQty { get; set; } = 1;
    public int MaxOrderQty { get; set; } = 100;

    public required string CGSTId { get; set; }
    public required string SGSTId { get; set; }
    public required string IGSTId { get; set; }
    public required string UOMId { get; set; }
    public required string StockId { get; set; }
    public required string StoreId { get; set; }

    [ForeignKey(nameof(SubCategory))]
    public required string SubCategoryId { get; set; }

    public required virtual Uom Uom { get; set; }
    public required virtual Stock Stock { get; set; }
    public required virtual Store Store { get; set; }

    public virtual ICollection<Color> Colors { get; set; } = [];
    public virtual ICollection<Size> Sizes { get; set; } = [];
    public virtual ICollection<Image> Images { get; set; } = [];

    //public Product():base() { }//for EF Core
    //public Product(
    //    string? userId,
    //    string code,
    //    string name,
    //    string? description,
    //    decimal mrp,
    //    decimal price,
    //    decimal amount,
    //    DateOnly expaireDate,
    //    int minOrderQty,
    //    int maxOrderQty,
    //    string cGSTId,
    //    string sGSTId,
    //    string iGSTId,
    //    string uomId,
    //    string stockId,
    //    string storeId,
    //    string subCategoryId
    //    ):base(userId,code,name,description) {

    //    MRP = mrp;
    //    Price = price;
    //    Amount = amount;
    //    ExpaireDate = expaireDate;
    //    MinOrderQty = minOrderQty;
    //    MaxOrderQty = maxOrderQty;
    //    CGSTId = cGSTId;
    //    SGSTId = sGSTId;
    //    IGSTId = iGSTId;
    //    UOMId = uomId;
    //    StockId = stockId;
    //    StoreId = storeId;
    //    SubCategoryId = subCategoryId;
    //    Colors = [];
    //    Sizes = [];
    //    Images = [];
    //}

    //public Color CreateColor(
    //     string? userId,
    //     string name,
    //     string? description,
    //     string hex
    //    ) {
    //    Color color = new(userId, name, description, hex);
    //    Colors.Add(color);
    //    return color;
    //}
    //public Size CreateSize(
    //     string? userId,
    //     string code,
    //     string name,
    //     string? description
    //    ) {
    //    Size size = new(userId,code,name,description);
    //    Sizes.Add(size);
    //    return size;
    //}
    //public Image CreateImage(
    //     string? userId,
    //     string imagePath
    //    ) {
    //    Image img = new(userId,imagePath,this.Id);
    //    Images.Add(img);
    //    return img;
    //}

}
