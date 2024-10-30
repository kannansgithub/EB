using EB.Domain.Shared;

namespace EB.Domain.Entities;

public class Color:AuditableEntity
{
    public required string Name { get; set; }
    public required string Hex { get; set; }
}
