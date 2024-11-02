using EB.Domain.Interfaces;

namespace EB.Domain.Bases;

public abstract class BaseEntityAudit : BaseEntity, IHasIsDeleted, IAggregateRoot
{
    protected BaseEntityAudit() { } // for EF Core
    protected BaseEntityAudit(string? userId)
    {
        IsDeleted = false;
        CreatedAt = DateTime.UtcNow;
        CreatedBy = userId?.Trim();
    }
    public bool IsDeleted { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public BaseEntityAudit SetAsDeleted(string? userId)
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = userId?.Trim();
        return this;
    }
    public BaseEntityAudit SetAsUpdated(string? userId)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = userId?.Trim();
        return this;
    }
}
