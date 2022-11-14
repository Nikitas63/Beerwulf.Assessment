using System;
using System.Threading.Tasks;
using Review.Contracts.Entities;
using Review.Contracts.Pagination;

namespace Review.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<Page<Product>> GetProductsAsync(int page = 1, int size = int.MaxValue);

        Task<Product> GetProductAsync(Guid productId);

    }
}