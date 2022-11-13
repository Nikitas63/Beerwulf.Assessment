using System;
using System.Threading.Tasks;
using Review.Contracts.BusinessModels;
using Review.Contracts.Entities;
using Review.Contracts.Pagination;
using Review.Contracts.Result;

namespace Review.Contracts.Services
{
    public interface IProductReviewService
    {
        Task<OperationResult<ProductReview>> CreateProductReviewAsync(ProductReview review);
        
        Task<ProductReviewsSummary> GetProductReviewsSummaryAsync(Guid productId);
        
        Task<Page<ProductReview>> GetProductReviewsAsync(Guid productId, int page = 1, int size = 20);
    }
}