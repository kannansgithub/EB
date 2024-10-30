namespace EB.Domain.Abstrations;

public record ProductDetail(
    string Id,
    string Name,
    string Description,
    string Sku,
    decimal MRP,
    decimal Price,
    decimal Amount,
    DateOnly ExpaireDate,
    int MinOrderQty,
    int MaxOrderQty,
    string CGST,
    string SGST,
    string IGST,
    string Uom,
    string UomSymbol,
    int Stock,
    int LastSale,
    string CategoryName,
    string CategoryDescription,
    string SubCategoryName,
    string SubCategoryDescription
);


