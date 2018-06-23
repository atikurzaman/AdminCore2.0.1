using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.EntityConfiguration
{
    public class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {       
        public void Configure(EntityTypeBuilder<Category> builder)
        {            
            builder.Property(c=>c.Id).ValueGeneratedOnAdd();
            builder.Property(c =>c.Name).HasMaxLength(256).IsRequired();
            builder.ToTable("Category");            
        }
    }
}
