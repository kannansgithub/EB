using EB.Domain.Entities;
using EB.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EB.Persistence.Configurations;
internal class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion(
            productId => productId.Value,
            value => new PrimarytId(value));
        builder.Property(p => p.SaleOrderId).HasConversion(
          saleOrderId => saleOrderId.Value,
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
        builder.OwnsOne(p => p.CGST, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency).HasMaxLength(3);
        });
        builder.OwnsOne(p => p.SGST, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency).HasMaxLength(3);
        });
        builder.OwnsOne(p => p.IGST, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency).HasMaxLength(3);
        });
        builder.Property(p => p.Sku).HasConversion(
            sku => sku.Value,
            value => Sku.Create(value)!);
    }
}
