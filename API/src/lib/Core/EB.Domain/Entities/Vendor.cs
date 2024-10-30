using EB.Domain.Shared;

namespace EB.Domain.Entities;

public class Vendor:AuditableEntity
{
    public required string Name { get; set; }
    public required string GSTN { get; set; }
    public required string ContactPerson { get; set; }
    public required string PrimaryContact { get; set; }
    public required decimal Balance { get; set; } = 0.0M;

    public virtual ICollection<Address> Addresses { get; set; } = [];
}
