using AutoMapper;
using E_CommerceAPI.DTOs;
using E_CommerceAPI.Models;

namespace E_CommerceAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>();
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetProductDTO>>> AddProduct(AddProductDTO newProduct)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDTO>>();
            var product = _mapper.Map<Product>(newProduct);
            product.ProductID = _products.Max(p => p.ProductID);
            _products.Add(_mapper.Map<Product>(newProduct));
            serviceResponse.Data = _products.Select(p => _mapper.Map<GetProductDTO>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDTO>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductDTO>>();
            serviceResponse.Data = _products.Select(p => _mapper.Map<GetProductDTO>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDTO>> GetProductById(int id)
        {
            var serviceResponse = new ServiceResponse<GetProductDTO>();
            var product = _products.FirstOrDefault(p => p.ProductID == id);
            serviceResponse.Data = _mapper.Map<GetProductDTO>(product);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDTO>> UpdateProduct(UpdateProductDTO updatedProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductDTO>();
            try
            {
                var product = _products.FirstOrDefault(p => p.ProductID == updatedProduct.ProductID);
                if (product == null)
                    throw new Exception($"Product with ID '{updatedProduct.ProductID}' not found");

                product.ProductName = updatedProduct.ProductName;
                product.ProductDescription = updatedProduct.ProductDescription;
                product.ProductImages = updatedProduct.ProductImages;
                product.Price = updatedProduct.Price;

                serviceResponse.Data = _mapper.Map<GetProductDTO>(_products);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
