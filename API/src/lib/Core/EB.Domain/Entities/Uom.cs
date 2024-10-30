using EB.Domain.Shared;

namespace EB.Domain.Entities;

public class Uom:AuditableEntity
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Symbol { get; set; }
}
