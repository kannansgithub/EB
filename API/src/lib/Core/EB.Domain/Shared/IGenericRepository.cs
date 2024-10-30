using System.Linq.Expressions;

namespace EB.Domain.Shared;

public interface IGenericRepository<T> where T : class, IAuditableEntity
{
    Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    IQueryable<T> Get(params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
}
