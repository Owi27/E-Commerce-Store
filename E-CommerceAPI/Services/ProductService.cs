using E_CommerceAPI.Models;

namespace E_CommerceAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>();
        public async Task<List<Product>> AddProduct(Product newProduct)
        {
           _products.Add(newProduct);
            return _products;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return _products;
        }

        public async Task<Product> GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.ProductID == id);
        }
    }
}
