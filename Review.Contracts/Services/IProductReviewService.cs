using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Review.Contracts.BusinessModels;
using Review.Contracts.Entities;

namespace Review.Contracts.Services
{
    public interface IProductReviewService
    {
        Task<ProductReview> CreateProductReviewAsync(ProductReview review);
        
        Task<ProductReviewsSummary> GetProductReviewsSummaryAsync(Guid productId);
        
        Task<IEnumerable<ProductReview>> GetProductReviewsAsync(Guid productId);
    }
}