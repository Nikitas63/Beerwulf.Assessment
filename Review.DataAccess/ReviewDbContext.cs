using Microsoft.EntityFrameworkCore;
using Review.Contracts.Entities;

namespace Review.DataAccess
{
    public class ReviewDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BeerWulfReview");
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
    }
}