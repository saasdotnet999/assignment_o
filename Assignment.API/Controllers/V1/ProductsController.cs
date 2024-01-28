using Assignment.Business.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[TypeFilter(typeof(TokenAuthorizationFilter))]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

      
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("ByColor/{color}")]
        public IActionResult GetProductsByColor(string color)
        {
            var products = _productService.GetProductsByColor(color);
            return Ok(products);
        }
    }
}
