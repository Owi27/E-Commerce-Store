using AutoMapper;
using E_CommerceAPI.DTOs;
using E_CommerceAPI.Models;

namespace E_CommerceAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Product, GetProductDTO>();
            CreateMap<AddProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
        }
    }
}
