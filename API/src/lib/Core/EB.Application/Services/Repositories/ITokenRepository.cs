using EB.Domain.Entities;

namespace EB.Application.Services.Repositories;

public interface ITokenRepository : IBaseCommandRepository<Token>
{
    Task<Token> GetByRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);
    Task<List<Token>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
}
