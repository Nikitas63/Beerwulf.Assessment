using System;
using System.Linq;
using System.Threading.Tasks;
using Review.Business.Extensions;
using Review.Contracts.Entities;
using Review.Contracts.Pagination;
using Review.Contracts.Repositories;

namespace Review.DataAccess.Repositories
{
    public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly ProductReviewDbContext _dbContext;
        public ProductReviewRepository(ProductReviewDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        
        public async Task<ProductReview> CreateProductReviewAsync(ProductReview review)
        {
            //TODO: create base entity repository for CRUD operations
            review.ProductReviewId = Guid.NewGuid(); // imitation of Id generation on DB side
            _dbContext.ProductReviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }

        public async Task<Page<ProductReview>> GetProductReviewsAsync(Guid productId, int page = 1, int size = int.MaxValue)
        {
            var query = _dbContext.ProductReviews.Where(r => r.ProductId == productId);
            return await query.ToPageAsync(page, size);
        }
    }
}