using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.EntityConfiguration
{
    public class EntityRecordMap : IEntityTypeConfiguration<EntityRecord>
    {
        public void Configure(EntityTypeBuilder<EntityRecord> builder)
        {            
            builder.Property(m => m.CreatedDate).IsRequired();
            builder.Property(m => m.ModifiedDate);
            builder.Property(m => m.CreatedBy).IsRequired();
            builder.Property(m => m.ModifiedBy);
            builder.Property(m => m.IPAddress).HasMaxLength(128).IsRequired();
            builder.Property(m => m.MacAddress).HasMaxLength(128).IsRequired();
        }
    }
}
