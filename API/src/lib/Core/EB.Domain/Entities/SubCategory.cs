using EB.Domain.Bases;
using EB.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class SubCategory: BaseEntityCommon, IAggregateRoot
{
    [ForeignKey(nameof(Category))]
    public required string CategoryId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = [];
}
