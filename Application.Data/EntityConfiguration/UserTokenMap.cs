using Application.Domain.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration
{
    public class UserTokenMap : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.Property(ut => ut.LoginProvider).IsRequired().HasMaxLength(256);
            builder.Property(ut => ut.Name).IsRequired().HasMaxLength(256);
            builder.Property(ut => ut.Value).HasMaxLength(256);

            builder.HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });

            builder.HasOne(ut => ut.User)
                        .WithMany()
                        .HasForeignKey(ut => ut.UserId)
                        .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("UserToken");
        }
    }
}
