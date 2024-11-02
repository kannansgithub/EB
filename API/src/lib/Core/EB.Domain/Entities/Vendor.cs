using EB.Domain.Bases;
using EB.Domain.Interfaces;

namespace EB.Domain.Entities;

public class Vendor : BaseEntityCommon, IAggregateRoot
{
    public required string GSTN { get; set; }
    public required string ContactPerson { get; set; }
    public required string PrimaryContact { get; set; }
    public required decimal Balance { get; set; } = 0.0M;

    public virtual ICollection<Address> Addresses { get; set; } = [];
}
