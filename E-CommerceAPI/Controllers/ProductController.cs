using E_CommerceAPI.Models;
using E_CommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> Get()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Product>>> Get(int id) 
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> AddProduct(Product newProduct)
        {
            return Ok(await _productService.AddProduct(newProduct));
        }
    }
}
