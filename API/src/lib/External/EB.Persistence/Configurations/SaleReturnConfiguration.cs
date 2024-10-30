using EB.Domain.Entities;
using EB.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EB.Persistence.Configurations;

internal class SaleReturnConfiguration : IEntityTypeConfiguration<SaleReturn>
{
    public void Configure(EntityTypeBuilder<SaleReturn> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion(
            productId => productId.Value,
            value => new PrimarytId(value));
        builder.Property(p => p.SaleItemId).HasConversion(
          saleItemId => saleItemId.Value,
          value => new PrimarytId(value));
        builder.OwnsOne(p => p.MRP, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency).HasMaxLength(3);
        });
        builder.OwnsOne(p => p.Price, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency).HasMaxLength(3);
        });
        builder.OwnsOne(p => p.Amount, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency).HasMaxLength(3);
        });
        builder.OwnsOne(p => p.ReturnAmount, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency).HasMaxLength(3);
        });

    }
}
