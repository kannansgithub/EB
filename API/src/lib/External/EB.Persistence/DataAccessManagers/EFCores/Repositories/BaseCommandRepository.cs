using EB.Application.Extensions;
using EB.Application.Services.Repositories;
using EB.Domain.Bases;
using EB.Domain.Interfaces;
using EB.Persistence.DataAccessManagers.EFCores.Contexts;
using Microsoft.EntityFrameworkCore;


namespace EB.Persistence.DataAccessManagers.EFCores.Repositories;

public class BaseCommandRepository<T>(CommandContext context) : IBaseCommandRepository<T> where T : BaseEntity, IAggregateRoot
{
    protected readonly CommandContext _context = context;

    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(entity, cancellationToken);
    }

    public void Create(T entity)
    {

        _context.Add(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Update(entity);
    }

    public void Purge(T entity)
    {
        _context.Remove(entity);
    }

    public virtual async Task<T?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<T>()
            .ApplyIsDeletedFilter()
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        return entity;
    }

    public virtual T? Get(string id)
    {
        var entity = _context.Set<T>()
            .ApplyIsDeletedFilter()
            .SingleOrDefault(x => x.Id == id);

        return entity;
    }

    public virtual IQueryable<T> GetQuery()
    {
        var query = _context.Set<T>().AsQueryable();

        return query;
    }


}
