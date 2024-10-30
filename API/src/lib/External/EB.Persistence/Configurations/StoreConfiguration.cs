using EB.Domain.Entities;
using EB.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.Persistence.Configurations
{
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasConversion(
                productId => productId.Value,
                value => new PrimarytId(value));
            builder.Property(p => p.AddressId).HasConversion(
              addressId => addressId.Value,
              value => new PrimarytId(value));
            //builder.Property(p => p.ClientId).HasConversion(
            //  clientId => clientId.Value,
            //  value => new PrimarytId(value));
        }
    }
}
