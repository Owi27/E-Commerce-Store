using AutoMapper;
using E_CommerceAPI.Data;
using E_CommerceAPI.DTOs;
using E_CommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>();
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public ProductService(IMapper mapper, DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetProductDTO>>> AddProduct(AddProductDTO newProduct)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDTO>>();
            var product = _mapper.Map<Product>(newProduct);
            product.ProductID = await _dataContext.Products.MaxAsync(p => p.ProductID);
            await _dataContext.Products.AddAsync(_mapper.Map<Product>(newProduct));
            //serviceResponse.Data = await _dataContext.Products.Where(p=>p.ProductID == Get//_dataContext.Products.Select(p => _mapper.Map<GetProductDTO>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDTO>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductDTO>>();
            var dbProducts = await _dataContext.Products.ToListAsync();
            serviceResponse.Data = dbProducts.Select(p => _mapper.Map<GetProductDTO>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDTO>> GetProductById(int id)
        {
            var serviceResponse = new ServiceResponse<GetProductDTO>();
            var dbProduct = await _dataContext.Products.FirstOrDefaultAsync(p => p.ProductID == id);
            serviceResponse.Data = _mapper.Map<GetProductDTO>(dbProduct);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDTO>> UpdateProduct(UpdateProductDTO updatedProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductDTO>();
            try
            {
                var product = await _dataContext.Products.FirstOrDefaultAsync(p => p.ProductID == updatedProduct.ProductID);
                if (product == null)
                    throw new Exception($"Product with ID '{updatedProduct.ProductID}' not found");

                _mapper.Map<Product>(updatedProduct);

                product.ProductName = updatedProduct.ProductName;
                product.ProductDescription = updatedProduct.ProductDescription;
                product.ImageUri = updatedProduct.ImageUri;
                product.Price = updatedProduct.Price;

                serviceResponse.Data = _mapper.Map<GetProductDTO>(_dataContext.Products);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDTO>>> DeleteProduct(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDTO>>();
            try
            {
                var product = _products.First(p => p.ProductID == id);
                if (product == null)
                    throw new Exception($"Product with ID '{id}' not found");

                _products.Remove(product);

                serviceResponse.Data = _products.Select(p => _mapper.Map<GetProductDTO>(p)).ToList();
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
