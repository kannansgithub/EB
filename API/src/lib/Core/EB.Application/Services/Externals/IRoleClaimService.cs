using System.Security.Claims;

namespace EB.Application.Services.Externals;

public interface IRoleClaimService
{
    Task<List<Claim>> GetClaimListByUserAsync(
        string userId,
        CancellationToken cancellationToken = default);
    Task<List<Claim>> GetClaimListAsync(
        CancellationToken cancellationToken = default);
    Task<List<string>> GetRoleListByUserAsync(string userId);

}
