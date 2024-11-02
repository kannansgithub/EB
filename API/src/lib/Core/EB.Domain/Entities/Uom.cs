using EB.Domain.Bases;
using EB.Domain.Interfaces;

namespace EB.Domain.Entities;

public class Uom : BaseEntityAdvance, IAggregateRoot
{
    public required string Symbol { get; set; }
}
