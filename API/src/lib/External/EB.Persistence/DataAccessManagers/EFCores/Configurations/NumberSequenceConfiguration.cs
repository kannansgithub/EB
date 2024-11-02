﻿using EB.Domain.Constants;
using EB.Domain.Entities;
using EB.Persistence.DataAccessManagers.EFCores.Configurations.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EB.Persistence.DataAccessManagers.EFCores.Configurations;


public class NumberSequenceConfiguration : BaseEntityAuditConfiguration<NumberSequence>
{
    public override void Configure(EntityTypeBuilder<NumberSequence> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.EntityName)
            .IsRequired()
            .HasMaxLength(NameConsts.MaxLength);

        builder.Property(x => x.LastUsedCount)
            .IsRequired();

        builder.Property(x => x.Prefix)
            .HasMaxLength(NameConsts.MaxLength);

        builder.Property(x => x.Suffix)
            .HasMaxLength(NameConsts.MaxLength);

        builder.HasIndex(e => e.EntityName).HasDatabaseName("IX_NumberSequence_EntityName");
        builder.HasIndex(e => e.Prefix).HasDatabaseName("IX_NumberSequence_Prefix");
        builder.HasIndex(e => e.Suffix).HasDatabaseName("IX_NumberSequence_Suffix");

    }
}

