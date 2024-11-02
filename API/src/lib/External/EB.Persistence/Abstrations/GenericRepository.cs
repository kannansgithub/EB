using EB.Domain.Interfaces;
using EB.Persistence;
using EB.Persistence.DataAccessManagers.EFCores.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EB.Persistence.Abstrations;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IAggregateRoot
{
    protected readonly DataContext _dbContext;

    protected GenericRepository(DataContext context) => _dbContext = context;

    public async Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Task.Factory.StartNew(() => _dbContext.Set<T>().Remove(entity), cancellationToken);
    }

    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        return await Task.Factory.StartNew(() => _dbContext.Set<T>().Update(entity).Entity, cancellationToken);
    }

    public IQueryable<T> Get(params Expression<Func<T, object>>[] includes)
    {
        IIncludableQueryable<T, object>? query = null;
        for (int queryIndex = 0; queryIndex < includes.Length; ++queryIndex)
        {
            query ??= _dbContext.Set<T>().Include(includes[queryIndex]);
            query = query.Include(includes[queryIndex]);
        }
        return query == null ? _dbContext.Set<T>() : query;
    }
}
