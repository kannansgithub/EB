

using EB.Application.Shared.Contracts;

namespace EB.Application.Services.Externals;

public interface INavigationService
{
    Task<GetMainNavResult> GenerateMainNavAsync(string userId, CancellationToken cancellationToken = default);
}
