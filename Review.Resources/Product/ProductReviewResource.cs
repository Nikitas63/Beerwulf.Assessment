using System;

namespace Review.Resources.Product
{
    public class ProductResource
    {        
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
    }
}