using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.EntityConfiguration
{
    public class BaseEntityMap : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {           
            builder.Property(m => m.CreatedDate).IsRequired().HasDefaultValueSql("GetDate()"); 
            builder.Property(m => m.ModifiedDate).IsRequired(false);
            builder.Property(m => m.CreatedBy).IsRequired();
            builder.Property(m => m.ModifiedBy).IsRequired(false); ;
            builder.Property(m => m.IPAddress).HasMaxLength(256).IsRequired(false);
            builder.Property(m => m.MacAddress).HasMaxLength(256).IsRequired(false);
        }
    }
}
