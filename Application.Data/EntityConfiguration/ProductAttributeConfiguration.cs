using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.EntityConfiguration
{
    public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {       
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {            
            builder.Property(c=>c.Id).ValueGeneratedOnAdd();
            builder.Property(c =>c.Name).HasMaxLength(128).IsRequired();
            builder.Property(c => c.OrderBy).HasMaxLength(128).IsRequired();
            builder.Property(c => c.Status).IsRequired().HasDefaultValue(true);
            builder.ToTable("ProductAttribute");            
        }
    }
}
