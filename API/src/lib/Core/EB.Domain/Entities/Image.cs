using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class Image: AuditableEntity
{
    public required string ImagePath { get; set; }
    [ForeignKey(nameof(Product))]
    public required string ProductId { get; set; }
}
