using EB.Domain.Abstrations;
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
    internal class AuditableEntityConfiguration : IEntityTypeConfiguration<AuditableEntity>
    {
        public void Configure(EntityTypeBuilder<AuditableEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasConversion(
                addressId => addressId.Value,
                value => new PrimarytId(value));
        }
    }
}
