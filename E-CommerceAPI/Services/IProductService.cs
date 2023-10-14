using E_CommerceAPI.Models;

namespace E_CommerceAPI.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetAllProducts();
        Task<ServiceResponse<Product>> GetProductById(int id);
        Task<ServiceResponse<List<Product>>> AddProduct(Product newProduct);
    }
}