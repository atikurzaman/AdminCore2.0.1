using Application.Domain;
using Application.Domain.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration
{
    public class UserClaimMap : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.Property(uc => uc.Id).ValueGeneratedOnAdd();
            builder.Property(uc => uc.ClaimType).HasMaxLength(1024).IsRequired();
            builder.Property(uc => uc.ClaimValue).HasMaxLength(1024).IsRequired();
            builder.Property(uc => uc.UserId);
            builder.HasKey(uc => uc.UserId);
            builder.HasIndex(uc => uc.UserId);

            builder.HasOne(uc=>uc.User)
                        .WithMany()
                        .HasForeignKey(uc=>uc.UserId)
                        .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("UserClaim");
        }
    }
}
