using EB.Domain.Shared;

namespace EB.Domain.Entities;

public class Customer:AuditableEntity
{
    public required string Name { get; set; }
    public string GSTN { get; set; } = string.Empty;
    public required string Contact { get; set; }
    public int Points { get; set; } = 0;
    public required decimal Balance { get; set; } = 0.0M;

    public virtual ICollection<Address> Addresses { get; set; } = [];
}
