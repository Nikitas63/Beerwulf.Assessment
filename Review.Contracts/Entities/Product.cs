using System;
using System.Collections.Generic;

namespace Review.Contracts.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        
        public IEnumerable<ProductReview> ProductReviews { get; set; }
    }
}