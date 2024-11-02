using EB.Domain.Bases;
using EB.Domain.Constants;
using EB.Persistence.SecurityManagers.AspNetIdentity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EB.Persistence.DataAccessManagers.EFCores.Configurations.Bases;

public abstract class BaseEntityAuditConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntityAudit
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        //BaseEntity
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasMaxLength(IdConsts.MaxLength).IsRequired();

        //BaseEntityAudit
        builder.Property(e => e.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .IsRequired(false);

        builder.Property(e => e.CreatedBy)
            .IsRequired(false)
            .HasMaxLength(UserIdConsts.MaxLength);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(e => e.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.UpdatedAt)
            .IsRequired(false);

        builder.Property(e => e.UpdatedBy)
            .HasMaxLength(UserIdConsts.MaxLength)
            .IsRequired(false);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(e => e.UpdatedBy)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
