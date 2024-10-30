using System.ComponentModel.DataAnnotations;

namespace EB.Domain.Shared;

public class AuditableEntity : IAuditableEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
    public string ModifiedBy { get; set; } = string.Empty;
    public bool IsActive { get; set; } = false;
}
