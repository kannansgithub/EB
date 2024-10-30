using EB.Domain.Enums;
using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class Counter:AuditableEntity
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public CounterType CounterType { get; set; } = CounterType.ALL;
    [ForeignKey(nameof(Store))]
    public required string StoreId { get; set; }

}
