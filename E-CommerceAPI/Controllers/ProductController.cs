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
        public ActionResult<List<Product>> Get()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id) 
        {
            return Ok(_productService.GetProductById(id));
        }

        [HttpPost]
        public ActionResult<List<Product>> AddProduct(Product newProduct)
        {
            return Ok(_productService.AddProduct(newProduct));
        }
    }
}
