using EB.Domain.Bases;
using EB.Domain.Enums;
using EB.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class Counter : BaseEntityAdvance, IAggregateRoot
{
    public CounterType CounterType { get; set; } = CounterType.ALL;
    [ForeignKey(nameof(Store))]
    public required string StoreId { get; set; }

}
