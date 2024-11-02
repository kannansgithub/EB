using EB.Application.Services.Repositories;
using EB.Domain.Entities;
using EB.Persistence.DataAccessManagers.EFCores.Contexts;
using EB.Persistence.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.DataAccessManagers.EFCores.Repositories;

public class TokenRepository(CommandContext context) : BaseCommandRepository<Token>(context), ITokenRepository
{
    public async Task<Token> GetByRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken)
    {
        var entity = await _context.Token
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.RefreshToken == refreshToken, cancellationToken);

        if (entity == null)
        {
            throw new TokenRepositoryException($"Refresh token has expired, please re-login. {refreshToken}");
        }
        return entity;
    }
    public async Task<List<Token>> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        var entities = await _context.Token
            .Where(x => x.UserId == userId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return entities;
    }
}
