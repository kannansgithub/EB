using EB.Domain.Bases;
using EB.Domain.Interfaces;

namespace EB.Domain.Entities;

public class Currency : BaseEntityAdvance, IAggregateRoot
{
    public string Symbol { get; set; } = null!;

    public Currency() : base() { } //for EF Core
    public Currency(
        string? userId,
        string code,
        string name,
        string symbol,
        string? description
        ) : base(userId, code, name, description)
    {
        Symbol = symbol;
    }

    public void Update(
        string? userId,
        string code,
        string name,
        string symbol,
        string? description
        )
    {
        Code = code.Trim();
        Name = name.Trim();
        Symbol = symbol.Trim();
        Description = description?.Trim();

        SetAsUpdated(userId);
    }

    public void Delete(string? userId)
    {
        SetAsDeleted(userId);
    }
}
