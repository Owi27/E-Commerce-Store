using E_CommerceAPI.DTOs;
using E_CommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Services
{
    public interface ICheckoutService
    {
        Task<ServiceResponse<CheckoutOrderResponse>> CheckoutOrder([FromBody] GetProductDTO product, [FromServices] IServiceProvider serviceProvider);
        Task<CheckoutOrderResponse> Checkout(GetProductDTO product);
    }
}
