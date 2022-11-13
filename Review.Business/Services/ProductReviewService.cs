using System;
using System.Linq;
using System.Threading.Tasks;
using Review.Contracts.BusinessModels;
using Review.Contracts.Entities;
using Review.Contracts.Pagination;
using Review.Contracts.Repositories;
using Review.Contracts.Result;
using Review.Contracts.Services;

namespace Review.Business.Services
{
    public class ProductReviewService: IProductReviewService
    {
        private const byte ScoreMinValue = 1;
        private const byte ScoreMaxValue = 5;
        
        private readonly IProductReviewRepository _repository;
        
        public ProductReviewService(IProductReviewRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        
        /// <summary>
        /// Creates new product review
        /// </summary>
        /// <param name="review">Product review to create</param>
        /// <returns>Operation result with created product review</returns>
        public async Task<OperationResult<ProductReview>> CreateProductReviewAsync(ProductReview review)
        {
            // TODO: move to separate validation service
            if (review == null)
                return OperationResult<ProductReview>.CreateInvalid(nameof(review), "Product review is null");
            if (string.IsNullOrWhiteSpace(review.ProductReviewTitle))
                return OperationResult<ProductReview>.CreateInvalid(nameof(review.ProductReviewTitle), "Title should be filled");
            if (review.ProductReviewScore < ScoreMinValue || review.ProductReviewScore > ScoreMaxValue)
                return OperationResult<ProductReview>.CreateInvalid(nameof(review.ProductReviewScore), 
                    $"Score should be from {ScoreMinValue} to {ScoreMaxValue}");

            var createdReview = await _repository.CreateProductReviewAsync(review);
            
            return OperationResult<ProductReview>.Create(createdReview);
        }

        /// <summary>
        /// Gets product review summary
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Product review summary</returns>
        public async Task<ProductReviewsSummary> GetProductReviewsSummaryAsync(Guid productId)
        {
            var reviews = await _repository.GetProductReviewsAsync(productId);
            if (!reviews.Data.Any())
                return new ProductReviewsSummary();
            
            var scores = reviews.Data.Select(r => r.ProductReviewScore).ToList();
            var averageScore = scores.Sum() / scores.Count;
            var percentOfRecommendations = reviews.Data.Count(r => r.ProductReviewIsRecommend == true)
                                           / reviews.Data.Count();

            return new ProductReviewsSummary
            {
                AverageScore = averageScore,
                PercentOfRecommendations = percentOfRecommendations
            };
        }

        /// <summary>
        /// Gets paged result of all product reviews
        /// </summary>
        /// <param name="productId">Product review</param>
        /// <param name="page">Page number</param>
        /// <param name="size">Size number</param>
        /// <returns>Paged result</returns>
        public async Task<Page<ProductReview>> GetProductReviewsAsync(Guid productId, int page = 1, int size = 20)
        {
            // TODO: move to validation service
            if (page <= 0 || size <= 0)
                return new Page<ProductReview>();

            return await _repository.GetProductReviewsAsync(productId, page, size);
        }
    }
}