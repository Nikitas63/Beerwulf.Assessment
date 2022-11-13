using System;
using System.Threading.Tasks;
using Review.Contracts.Entities;
using Review.Contracts.Pagination;

namespace Review.Contracts.Repositories
{
    public interface IProductReviewRepository
    {
        Task<ProductReview> CreateProductReviewAsync(ProductReview review);

        Task<Page<ProductReview>> GetProductReviewsAsync(Guid productId, int page = 1, int size = int.MaxValue);
    }
}