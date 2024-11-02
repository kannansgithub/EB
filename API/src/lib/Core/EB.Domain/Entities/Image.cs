using EB.Domain.Bases;
using EB.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class Image: BaseEntityAudit, IAggregateRoot
{
    public required string ImagePath { get; set; }
    [ForeignKey(nameof(Product))]
    public required string ProductId { get; set; }

    //public Image() : base() { } //for EF Core
    //public Image(
    //     string? userId,
    //     string imagePath,
    //     string productId
    //) : base(userId) {
    
    //    ImagePath= imagePath;
    //    ProductId= productId;
    //}
    //public void Update(
    //     string? userId,
    //     string imagePath,
    //     string productId
    //)
    //{

    //    ImagePath = imagePath;
    //    ProductId = productId;
    //    SetAsUpdated(userId);
    //}
    //public void Delete(string? userId)
    //{

    //    SetAsDeleted(userId);
    //}

}
