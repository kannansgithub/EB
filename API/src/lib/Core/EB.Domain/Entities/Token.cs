using EB.Domain.Bases;
using EB.Domain.Constants;
using EB.Domain.Interfaces;

namespace EB.Domain.Entities;

public class Token : BaseEntity, IAggregateRoot
{

    public string UserId { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTimeOffset ExpiryDate { get; set; }
    public Token() : base() { } //for EF Core
    public Token(
        string userId,
        string refreshToken
    )
    {
        UserId = userId.Trim();
        RefreshToken = refreshToken.Trim();
        ExpiryDate = DateTime.UtcNow.AddDays(TokenConsts.ExpiryInDays);
    }
}
