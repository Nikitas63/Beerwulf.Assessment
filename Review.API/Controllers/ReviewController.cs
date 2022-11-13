using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Review.Contracts.Entities;
using Review.Contracts.Result;
using Review.Contracts.Services;
using Review.Resources.Pagination;
using Review.Resources.ProductReview;
using Review.Resources.ProductReview.Create;

namespace Review.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private readonly IProductReviewService _productReviewService;
        private readonly IMapper _mapper;

        public ReviewController(
            IProductReviewService productReviewService,
            IMapper mapper)
        {
            _productReviewService = productReviewService ?? throw new ArgumentNullException(nameof(productReviewService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Gets paged product reviews by product id
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Paged product reviews</returns>
        [HttpGet]
        [Route("{productId:guid}")]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(PageResource<ProductReview>))]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetProductReviews(Guid productId, int pageNumber = 1, int pageSize = 20)
        {
            var result = await _productReviewService.GetProductReviewsAsync(productId, pageNumber, pageSize);

            return Ok(_mapper.Map<PageResource<ProductReview>>(result));
        }
        
        /// <summary>
        /// Gets product review summary
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>Product review summary</returns>
        [HttpGet]
        [Route("summary/{productId:guid}")]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(ProductReviewResource))]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetProductReviewsSummary(Guid productId)
        {
            var result = await _productReviewService.GetProductReviewsSummaryAsync(productId);

            return Ok(_mapper.Map<ProductReviewResource>(result));
        }
        
        /// <summary>
        /// Gets product review summary
        /// </summary>
        /// <param name="productReview">Product review to create</param>
        /// <returns>Created product review</returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(ProductReviewCreateResponseResource))]
        [ProducesResponseType((int) HttpStatusCode.BadRequest, Type = typeof(ProductReviewCreateResponseResource))]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateProductReview(ProductReviewCreateRequestResource productReview)
        {
            var operationResult = await _productReviewService.CreateProductReviewAsync(_mapper.Map<ProductReview>(productReview));
            var result = _mapper.Map<ProductReviewCreateResponseResource>(operationResult);

            return operationResult.Status switch
            {
                OperationStatus.Success => Ok(result),
                OperationStatus.InvalidInput => BadRequest(result),
                OperationStatus.Conflict => Conflict(result),
                OperationStatus.NotFound => NotFound(result),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
    }
}