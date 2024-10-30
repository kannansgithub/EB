using EB.Domain.Entities;
using EB.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EB.Persistence.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion(
            productId => productId.Value,
            value => new PrimarytId(value));
        builder.Property(p => p.Sku).HasConversion(
            sku => sku.Value,
            value => Sku.Create(value)!);
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
        builder.Property(p => p.SubCategoryId).HasConversion(
           subCategoryId => subCategoryId.Value,
           value => new PrimarytId(value));

        builder.Property(p => p.CGSTId).HasConversion(
           cgstId => cgstId.Value,
           value => new PrimarytId(value));
        builder.Property(p => p.SGSTId).HasConversion(
           sgstId => sgstId.Value,
           value => new PrimarytId(value));
        builder.Property(p => p.IGSTId).HasConversion(
           igstId => igstId.Value,
           value => new PrimarytId(value));

        builder.Property(p => p.UOMId).HasConversion(
           uomId => uomId.Value,
           value => new PrimarytId(value));
        builder.Property(p => p.StockId).HasConversion(
           stockId => stockId.Value,
           value => new PrimarytId(value));
        builder.HasOne(x => x.CGSTId)
            .WithMany()
            .HasForeignKey(p => p.Tax);
        builder.HasOne(x => x.SGSTId)
            .WithMany()
            .HasForeignKey(p => p.Tax);
        builder.HasOne(x => x.IGSTId)
            .WithMany()
            .HasForeignKey(p => p.Tax);
    }
}
