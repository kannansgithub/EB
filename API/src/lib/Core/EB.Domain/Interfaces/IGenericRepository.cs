using System.Linq.Expressions;

namespace EB.Domain.Interfaces;

public interface IGenericRepository<T> where T : class, IAggregateRoot
{
    Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    IQueryable<T> Get(params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
}
