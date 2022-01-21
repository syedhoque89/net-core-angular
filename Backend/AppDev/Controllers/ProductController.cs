using System.Collections.Generic;
using System.Threading.Tasks;
using AppDev.Models;
using AppDev.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppDev.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly ILogger<ProductController> _logger;
        readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Returns a collection of Product
        /// </summary>
        /// <returns cref='Product'/>
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            _logger.LogDebug($"Calling {nameof(ProductController)} HttpGet");

            var productList = await _productService.GetProductsAsync();

            // check for null and return 500 may be? May be? 🤔
            return productList?.Products;
        }
    }
}