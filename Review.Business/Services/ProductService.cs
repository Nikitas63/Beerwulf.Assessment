using System;
using System.Threading.Tasks;
using Review.Contracts.Entities;
using Review.Contracts.Pagination;
using Review.Contracts.Repositories;
using Review.Contracts.Services;

namespace Review.Business.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Gets paged result of all products
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="size">Size number</param>
        /// <returns>Paged result</returns>
        public async Task<Page<Product>> GetProductsAsync(int page = 1, int size = 20)
        {
            // TODO: move to validation service
            if (page <= 0 || size <= 0)
                return new Page<Product>();

            return await _repository.GetProductsAsync(page, size);
        }
    }
}