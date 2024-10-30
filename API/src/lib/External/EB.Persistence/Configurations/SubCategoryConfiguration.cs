using EB.Domain.Entities;
using EB.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EB.Persistence.Configurations;

internal class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion(
            productId => productId.Value,
            value => new PrimarytId(value));
        builder.Property(p => p.CategoryId).HasConversion(
          categoryId => categoryId.Value,
          value => new PrimarytId(value));
    }
}
