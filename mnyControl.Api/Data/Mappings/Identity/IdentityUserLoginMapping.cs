﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace mnyControl.Api.Data.Mappings.Identity
{
    public class IdentityUserLoginMapping
: IEntityTypeConfiguration<IdentityUserLogin<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<long>> builder)
        {
            builder.ToTable("IdentityUserLogin");
            builder.HasKey(l => new { l.LoginProvider, l.ProviderKey });
            builder.Property(l => l.LoginProvider).HasMaxLength(128);
            builder.Property(l => l.ProviderKey).HasMaxLength(128);
            builder.Property(u => u.ProviderDisplayName).HasMaxLength(255);
        }
    }
}
