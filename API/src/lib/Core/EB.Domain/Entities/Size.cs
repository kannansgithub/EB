using EB.Domain.Bases;
using EB.Domain.Interfaces;
using EB.Domain.Shared;

namespace EB.Domain.Entities;

public class Size: BaseEntityAdvance, IAggregateRoot
{
    public virtual ICollection<Product> Products { get; set; } = [];

    //public Size() { } //for EF Core
    //public Size(
    //     string? userId,
    //     string code,
    //     string name,
    //     string? description
    //) : base(userId,code, name, description)
    //{

      
    //} 
}
