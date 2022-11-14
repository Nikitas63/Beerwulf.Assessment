using System;
using Review.Contracts.Entities;
using Review.DataAccess;

namespace Review.API.AppStart
{
    public static class DataSeeder
    {
        public static void SeedData()
        {
            using (var context = new ProductReviewDbContext())
            {
                context.Database.EnsureCreated();
            
                context.Products.Add(new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Beerwulf Lager",
                    ProductDescription = "Lager beer...",
                    ProductPrice = 10.5
                });
            
                context.Products.Add(new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Beerwulf IPA",
                    ProductDescription = "IPA...",
                    ProductPrice = 15.5
                });
                
                context.Products.Add(new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Beerwulf Dubbel",
                    ProductDescription = "Dubbel...",
                    ProductPrice = 12
                });
                
                context.Products.Add(new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Beerwulf Tripel",
                    ProductDescription = "Tripel...",
                    ProductPrice = 13.5
                });
            
                context.SaveChanges();
            }
        }
    }
}