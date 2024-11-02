using EB.Domain.Enums;
using EB.Domain.Interfaces;

namespace EB.Domain.Bases;

public class BaseOrder : BaseEntityCommon, IAggregateRoot
{
    public BaseOrder()
    {
        TotalSaveOnMRP = TotalMRP - TotalAmount;
    }
    public required string InvoiceNumber { get; set; }
    public required decimal TotalAmount { get; set; }
    public required int TotalItems { get; set; }
    public required decimal TotalTax { get; set; }
    public required decimal TotalMRP { get; set; }
    public required decimal PaidAmount { get; set; }
    public required decimal Balance { get; set; }
    public required decimal DiscountAmount { get; set; }
    public decimal DiscountPercentage { get; set; } = 0.0M;
    public required decimal TotalSaveOnMRP { get; set; }
    public required TransactionType TransactionType { get; set; }
    public required PaymentMode PaymentMode { get; set; }
}
