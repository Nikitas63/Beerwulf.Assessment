using System.Threading.Tasks;
using Review.Contracts.Entities;
using Review.Contracts.Pagination;

namespace Review.Contracts.Services
{
    public interface IProductService
    {
        Task<Page<Product>> GetProductsAsync(int page = 1, int size = 20);
    }
}