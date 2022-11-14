using System;
using System.Threading.Tasks;
using Review.Business.Extensions;
using Review.Contracts.Entities;
using Review.Contracts.Pagination;
using Review.Contracts.Repositories;

namespace Review.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductReviewDbContext _dbContext;
        public ProductRepository(ProductReviewDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Page<Product>> GetProductsAsync(int page = 1, int size = int.MaxValue)
        {
            return await _dbContext.Products.ToPageAsync(page, size);
        }
    }
}