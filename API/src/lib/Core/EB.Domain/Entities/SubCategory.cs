using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class SubCategory:AuditableEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    [ForeignKey(nameof(Category))]
    public required string CategoryId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = [];
}
