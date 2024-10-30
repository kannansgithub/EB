using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class Stock:AuditableEntity
{
    public int CurrentStock { get; set; } = 0;
    public int LastSale { get; set; } = 0;

}
