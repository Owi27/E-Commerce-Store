using E_CommerceAPI.Models;

namespace E_CommerceAPI.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        List<Product> AddProduct(Product newProduct);
    }
}
