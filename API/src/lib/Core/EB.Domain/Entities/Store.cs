using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class Store:AuditableEntity
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    [ForeignKey(nameof(Address))]
    public required string AddressId { get; set; }
    public required string ClientId { get; set; }

    public virtual Address? Address { get; set; }
    public virtual Client? Client { get; set; }
    public virtual ICollection<Counter> Counters { get; set; } = [];

}
