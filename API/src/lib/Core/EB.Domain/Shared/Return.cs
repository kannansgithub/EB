namespace EB.Domain.Shared;

public class Return : AuditableEntity
{
    public required string InvoiceNumber { get; set; }
    public decimal MRP { get; set; } = 0.0M;
    public decimal Price { get; set; } = 0.0M;
    public decimal Amount { get; set; } = 0.0M;
    public int Quantity { get; set; } = 0;
    public decimal ReturnAmount { get; set; } = 0.0M;
    public bool IsAffectStock { get; set; } = false;
    public string? Note { get; set; }

}
