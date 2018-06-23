using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration
{
    public class ProductAttributeItemConfiguration:IEntityTypeConfiguration<ProductAttributeItem>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeItem> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(1024);
            builder.Property(c => c.Status).IsRequired().HasDefaultValue(true);
            builder.ToTable("ProductAttributeItem");
        }
    }
}
