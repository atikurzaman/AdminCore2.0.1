using Application.Domain.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration
{
    public class RoleClaimMap : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.Property(rc => rc.Id).ValueGeneratedOnAdd();
            builder.Property(rc => rc.ClaimType).HasMaxLength(1024).IsRequired();
            builder.Property(rc => rc.ClaimValue).HasMaxLength(1024).IsRequired();
            builder.HasKey(rc => rc.Id);
            builder.HasIndex(rc => rc.RoleId);

            builder.HasOne(rc=>rc.Role)
                       .WithMany()
                       .HasForeignKey(rc => rc.RoleId)
                       .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("RoleClaim");
        }
    }
}
