namespace EB.Domain.Shared;

public interface IAuditableEntity
{
    public string Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public string ModifiedBy { get; set; }
    public bool IsActive { get; set; }
}
