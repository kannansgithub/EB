using EB.Domain.Shared;

namespace EB.Domain.Entities;

public class Tax:AuditableEntity
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Symbol { get; set; }

    public virtual ICollection<Product> Products { get; set; } = [];

}
