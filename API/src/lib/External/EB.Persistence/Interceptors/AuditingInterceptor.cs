using EB.Domain.Bases;
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
                if(entry.Entity is BaseEntityCommon entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Deleted:
                        {
                                entity.IsDeleted = false;
                                entity.UpdatedAt = DateTime.UtcNow;
                                entity.UpdatedBy = string.Empty;//logic to fetch current user;
                                entry.State = EntityState.Modified;
                                break;
                        }
                        case EntityState.Added:
                            {
                                entity.IsDeleted = true;
                                entity.CreatedAt = DateTime.UtcNow;
                                entity.CreatedBy = string.Empty;//logic to fetch current user;
                                entry.State = EntityState.Added;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entity.UpdatedAt = DateTime.UtcNow;
                                entity.UpdatedBy = string.Empty;//logic to fetch current user;
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
