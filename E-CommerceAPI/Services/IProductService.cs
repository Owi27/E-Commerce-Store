using E_CommerceAPI.DTOs;
using E_CommerceAPI.Models;

namespace E_CommerceAPI.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductDTO>>> GetAllProducts();
        Task<ServiceResponse<GetProductDTO>> GetProductById(int id);
        Task<ServiceResponse<List<GetProductDTO>>> AddProduct(AddProductDTO newProduct);
        Task<ServiceResponse<GetProductDTO>> UpdateProduct(UpdateProductDTO updatedProduct);
        Task<ServiceResponse<List<GetProductDTO>>> DeleteProduct(int id);
    }
}