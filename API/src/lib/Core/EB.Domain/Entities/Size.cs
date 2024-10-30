using EB.Domain.Shared;

namespace EB.Domain.Entities;

public class Size:AuditableEntity
{
    public required string Code { get; set; }
    public required string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = [];
}
