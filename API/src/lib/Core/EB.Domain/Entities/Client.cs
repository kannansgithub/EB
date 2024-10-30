using EB.Domain.Shared;

namespace EB.Domain.Entities;

public class Client:AuditableEntity
{
    public required string Name { get; set; }
    public string LogoPath { get; set; } = string.Empty;
    public string PrimaryColor { get; set; } = string.Empty;
    public string SecondaryColor { get; set; } = string.Empty;
    public string TertiaryColor { get; set; } = string.Empty;
    public virtual ICollection<Store> Stores { get; set; } = [];

}
