using EB.Domain.Abstrations;
using EB.Domain.Entities;
using EB.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EB.Persistence.Configurations;

internal class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion(
            addressId => addressId.Value,
            value => new PrimarytId(value));

        builder.Property(p => p.CreatedBy).HasConversion(
            createdBy => createdBy.Value,
            value => new PrimarytId(value));
        builder.Property(p => p.ModifiedBy).HasConversion(
            modifiedBy => modifiedBy.Value,
            value => new PrimarytId(value));
        //builder.Property(p => p.StoreId).HasConversion(
        //    storeId => storeId.Value,
        //    value => new PrimarytId(value));
        //builder.Property(p => p.VendorId).HasConversion(
        //   vendorId => vendorId.Value,
        //   value => new PrimarytId(value));
        //builder.Property(p => p.CustomerId).HasConversion(
        //   customerId => customerId.Value,
        //   value => new PrimarytId(value));
    }
}
