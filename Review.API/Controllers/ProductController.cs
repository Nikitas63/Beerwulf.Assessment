using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Review.Contracts.Services;
using Review.Resources.Pagination;
using Review.Resources.Product;

namespace Review.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productReviewService;
        private readonly IMapper _mapper;

        public ProductController(
            IProductService productReviewService,
            IMapper mapper)
        {
            _productReviewService = productReviewService ?? throw new ArgumentNullException(nameof(productReviewService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Gets paged products
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Paged products</returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(PageResource<ProductResource>))]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetProducts(int pageNumber = 1, int pageSize = 20)
        {
            var result = await _productReviewService.GetProductsAsync(pageNumber, pageSize);

            return Ok(_mapper.Map<PageResource<ProductResource>>(result));
        }
    }
}