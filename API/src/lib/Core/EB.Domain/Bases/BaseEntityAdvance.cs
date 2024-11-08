namespace EB.Domain.Bases;

/// <summary>
/// Base class for advanced entities that extends <see cref="BaseEntityAudit"/>.
/// Adds properties for code, name, and an optional description, typically used for more complex entities that require both a code and a name.
/// </summary>
public abstract class BaseEntityAdvance : BaseEntityCommon
{
    public string Code { get; set; } = null!;

    protected BaseEntityAdvance() { } // for EF Core
    protected BaseEntityAdvance(
        string? userId,
        string code,
        string name,
        string? description
        ) : base(userId, name,description)
    {
        Code = code.Trim();
    }
}
