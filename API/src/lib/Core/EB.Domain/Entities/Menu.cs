using EB.Domain.Bases;

namespace EB.Domain.Entities;

public class Menu: BaseEntityAudit
{
    public required string Name { get; set; }
    public required string Caption { get; set; }
    public string URI { get; set; } = "#";
    public string? Icon { get; set; }
    public string? ParentId { get; set; }
    public string[] Roles { get; set; } = [];
    public virtual ICollection<Menu> Children { get; set; } = [];
}
