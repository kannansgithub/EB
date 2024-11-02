using EB.Domain.Bases;
using EB.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class Client: BaseEntityCommon, IAggregateRoot

{
    public string LogoPath { get; set; } = null!;
    public string FavIconPath { get; set; } = null!;
    public string? PageTitle { get; set; }
    public string? PageDescription { get; set; }
    public string PrimaryColor { get; set; } = null!;
    public string SecondaryColor { get; set; } = null!;
    public string TertiaryColor { get; set; } = null!;
    [ForeignKey(nameof(Address))]
    public required string AddressId { get; set; }
    public virtual ICollection<Store> Stores { get; set; } = [];

}
