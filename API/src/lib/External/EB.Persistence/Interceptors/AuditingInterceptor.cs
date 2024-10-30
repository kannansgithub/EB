using EB.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EB.Persistence.Interceptors;

public class AuditingInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        if (eventData.Context is not null)
        {
            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if(entry.Entity is AuditableEntity entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Deleted:
                        {
                            entity.IsActive = false;
                            entity.ModifiedOn = DateTime.UtcNow;
                                entity.ModifiedBy = string.Empty;//logic to fetch current user;
                                entry.State = EntityState.Modified;
                                break;
                        }
                        case EntityState.Added:
                            {
                                entity.IsActive = true;
                                entity.CreatedOn = DateTime.UtcNow;
                                entity.CreatedBy = string.Empty;//logic to fetch current user;
                                entry.State = EntityState.Added;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entity.ModifiedOn = DateTime.UtcNow;
                                entity.ModifiedBy = string.Empty;//logic to fetch current user;
                                entry.State = EntityState.Modified;
                                break;
                            }
                    }
                }
               
            }
        }
        return base.SavingChanges(eventData, result);
    }
}
