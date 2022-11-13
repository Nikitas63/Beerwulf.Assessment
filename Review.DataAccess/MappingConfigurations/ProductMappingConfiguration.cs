using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Review.Contracts.Entities;

namespace Review.DataAccess.MappingConfigurations
{
    public class ProductMappingConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.ProductName)
                .IsRequired();

            builder.Property(e => e.ProductDescription)
                .IsRequired();
            
            builder.Property(e => e.ProductPrice)
                .IsRequired();
        }
    }
}