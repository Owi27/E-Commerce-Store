using E_CommerceAPI.DTOs;
using E_CommerceAPI.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Stripe.Checkout;

namespace E_CommerceAPI.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IConfiguration _configuration;
        private static string clientURL = "http://localhost:5173/";
        
        public CheckoutService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<CheckoutOrderResponse> Checkout(GetProductDTO product)
        {
            //Create a payment flow from items in cart
            //Gets sent to stripe API
            var options = new SessionCreateOptions()
            {
                //Stripe calls these urls based on success or failure
                SuccessUrl = clientURL + "Success",
                CancelUrl = clientURL + "Failed",
                PaymentMethodTypes = new List<string>
                { 
                    "card"
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    new()
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = product.Price, //Last 2 spots are cents
                            Currency = "USD",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = product.ProductName,
                                Description = product.ProductDescription,
                                Images = new List<string> {product.ImageUri }
                            },
                        },
                        Quantity = 1
                    },
                },
                Mode = "payment"
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            var checkoutOrderResponse = new CheckoutOrderResponse
            {
                SessionID = session.Id,
                SessionUrl = session.Url,
                PubKey = _configuration["Stripe:PubKey"]
            };

            return checkoutOrderResponse;
        }

        public async Task<ServiceResponse<CheckoutOrderResponse>> CheckoutOrder([FromBody] GetProductDTO product, [FromServices] IServiceProvider serviceProvider)
        {
            //Build the URL that the customer will be directed to after paying
            var serviceResponse = new ServiceResponse<CheckoutOrderResponse>();

            var server = serviceProvider.GetRequiredService<IServer>();

            var serverAddressFeature = server.Features.Get<IServerAddressesFeature>();

            string? thisAPIUrl = null;

            if (serverAddressFeature != null)
            {
                thisAPIUrl = serverAddressFeature.Addresses.FirstOrDefault();
            }

            if (thisAPIUrl != null)
            {
                var checkoutOrderResponse = await Checkout(product);

                serviceResponse.Data = checkoutOrderResponse;
                serviceResponse.Success = true;
                
                return serviceResponse;
            }

            serviceResponse.Message = "API URL was null";
            serviceResponse.Success = false;

            return serviceResponse;
        }
    }
}
