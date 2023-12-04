using E_CommerceAPI.DTOs;
using E_CommerceAPI.Models;
using E_CommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CheckoutOrderResponse>>> CheckoutOrder([FromBody] GetProductDTO product, [FromServices] IServiceProvider serviceProvider)
        {
            return Ok(await _checkoutService.CheckoutOrder(product, serviceProvider));
        }

        [NonAction]
        public async Task<CheckoutOrderResponse> Checkout(GetProductDTO product)
        {
            return await _checkoutService.Checkout(product);
        }
    }
}
