using E_CommerceAPI.Models;

namespace E_CommerceAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>();
        public async Task<ServiceResponse<List<Product>>> AddProduct(Product newProduct)
        {
            var serviceResponse = new ServiceResponse<List<Product>>();
            _products.Add(newProduct);
            serviceResponse.Data = _products;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Product>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<Product>>();
            serviceResponse.Data = _products;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            var serviceResponse = new ServiceResponse<Product>();
            var character = _products.FirstOrDefault(p => p.ProductID == id);
            serviceResponse.Data = character;
            return serviceResponse;
        }
    }
}
