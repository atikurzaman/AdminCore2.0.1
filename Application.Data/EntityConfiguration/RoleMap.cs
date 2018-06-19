using Application.Domain;
using Application.Domain.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();
            builder.Property(r => r.Name).HasMaxLength(256).IsRequired();
            builder.Property(r => r.NormalizedName).HasMaxLength(256).IsRequired();
            builder.HasKey(r => r.Id);

            builder.HasIndex(r=>r.NormalizedName)
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

            builder.ToTable("Role");
        }
    }
}
