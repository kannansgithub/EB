using EB.Domain.Entities;
using EB.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EB.Persistence.Configurations;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion(
            customerId => customerId.Value,
            value => new PrimarytId(value));
        builder.OwnsOne(p => p.Balance, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency).HasMaxLength(3);
        });

    }
}
