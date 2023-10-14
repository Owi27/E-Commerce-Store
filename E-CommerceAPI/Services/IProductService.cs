using E_CommerceAPI.Models;

namespace E_CommerceAPI.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<List<Product>> AddProduct(Product newProduct);
    }
}