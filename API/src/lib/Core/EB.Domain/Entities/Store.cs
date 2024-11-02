using EB.Domain.Bases;
using EB.Domain.Interfaces;
using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class Store : BaseEntityAdvance, IAggregateRoot
{
    public bool IsOnline { get; set; }
    [ForeignKey(nameof(Address))]
    public required string AddressId { get; set; }
    public required string ClientId { get; set; }

    public virtual Address? Address { get; set; }
    public virtual Client? Client { get; set; }
    public virtual ICollection<Counter> Counters { get; set; } = [];

}
