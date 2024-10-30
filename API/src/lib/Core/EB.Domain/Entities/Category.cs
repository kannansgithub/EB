using EB.Domain.Shared;

namespace EB.Domain.Entities;

public class Category:AuditableEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
