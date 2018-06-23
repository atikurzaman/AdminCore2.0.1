using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Name).HasMaxLength(256).IsRequired();
            builder.Property(m => m.ControllerName).HasMaxLength(256).IsRequired();
            builder.Property(m => m.ActionName).HasMaxLength(256).IsRequired();
            builder.Property(m => m.MenuArea).HasMaxLength(256);
            builder.Property(m => m.Disable);
            builder.Property(m => m.HasAccess);
            builder.Property(m => m.ParentId);
            builder.HasKey(m => m.Id);
            builder.ToTable("Menu");
        }
    }
}
