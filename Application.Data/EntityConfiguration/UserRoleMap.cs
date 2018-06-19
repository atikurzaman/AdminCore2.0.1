using Application.Domain;
using Application.Domain.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {            
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });
            builder.HasIndex(ur => ur.RoleId);

            builder.HasOne(r=>r.Role)
                        .WithMany()
                        .HasForeignKey(r => r.RoleId)
                        .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u=>u.User)
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("UserRole");
        }
    }
}
