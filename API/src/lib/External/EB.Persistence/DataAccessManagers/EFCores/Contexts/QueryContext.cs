using EB.Application.Services.CQS.Queries;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.DataAccessManagers.EFCores.Contexts;

public class QueryContext(DbContextOptions<DataContext> options) : DataContext(options), IQueryContext
{
    public new IQueryable<T> Set<T>() where T : class
    {
        return base.Set<T>();
    }
}
