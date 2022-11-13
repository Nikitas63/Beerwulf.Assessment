using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Review.Contracts.Entities;

namespace Review.DataAccess.MappingConfigurations
{
    public class ProductReviewMappingConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.Property(e => e.ProductReviewScore)
                .IsRequired();

            builder.Property(e => e.ProductReviewTitle)
                .IsRequired();
            
            builder.HasOne(d => d.Product)
                .WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.ProductId);
        }
    }
}