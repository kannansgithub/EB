using EB.Domain.Bases;
using EB.Domain.Interfaces;

namespace EB.Domain.Entities;

public class Tax : BaseEntityAdvance, IAggregateRoot
{
    public required string Symbol { get; set; }

    public virtual ICollection<Product> Products { get; set; } = [];

}
