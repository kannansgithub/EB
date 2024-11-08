using EB.Domain.Abstrations;
using EB.Domain.Entities;

namespace EB.Domain.Services;

public interface IMenuService
{
    ICollection<Menu> GetAllAsync(List<string> roles, CancellationToken token = default);
}
