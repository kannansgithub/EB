using EB.Domain.Bases;
using EB.Domain.Interfaces;

namespace EB.Domain.Entities;

public class Color: BaseEntityCommon, IAggregateRoot
{
    public required string Hex { get; set; }
    //public Color() : base() { } //for EF Core
    //public Color(
    //     string? userId,
    //     string name,
    //     string? description,
    //     string hex
    //) : base(userId,name, description)
    //{

    //   Hex = hex.Trim();
    //}
    //public void Update(
    //     string? userId,
    //     string name,
    //     string? description,
    //     string hex
    //)
    //{
    //    Name = name.Trim();
    //    Description = description?.Trim();
    //    Hex = hex.Trim();
    //    SetAsUpdated(userId);
    //}
    //public void Delete(string? userId)
    //{
    //    SetAsDeleted(userId);
    //}
}
