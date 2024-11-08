using EB.Domain.Entities;
using EB.Domain.Interfaces;

namespace EB.Domain.Repositories;

public interface IMenuRepository: IGenericRepository<Menu>
{
    Task<ICollection<Menu>> GetAllAsync(List<string> roles , CancellationToken token = default);
}
