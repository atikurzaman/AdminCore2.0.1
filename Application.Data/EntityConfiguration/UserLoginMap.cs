using Application.Domain;
using Application.Domain.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration
{
    public class UserLoginMap : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.Property(ul => ul.LoginProvider).IsRequired().HasMaxLength(256);
            builder.Property(ul => ul.ProviderKey).IsRequired().HasMaxLength(256);
            builder.Property(ul => ul.ProviderDisplayName).HasMaxLength(256);

            builder.HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });
            builder.HasIndex(ul=>ul.UserId);

            builder.HasOne(ul => ul.User)
                        .WithMany()
                        .HasForeignKey(ul => ul.UserId)
                        .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("UserLogin");
        }
    }
}
