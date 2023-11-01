using E_CommerceAPI.Models;
using E_CommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace E_CommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterRequest request)
        {
            return Ok(await _userService.Register(request));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginRequest request)
        {
            return Ok(await _userService.Login(request));
        }

        [HttpPost("Verify")]
        public async Task<ActionResult<ServiceResponse<string>>> Verify(string token)
        {
            return Ok(await _userService.Verify(token));
        }

        [HttpPost("Forgot-Password")]
        public async Task<ActionResult<ServiceResponse<string>>> ForgotPassword(string email)
        {
            return Ok(await _userService.ForgotPassword(email));
        }

        [HttpPost("Reset-Password")]
        public async Task<ActionResult<ServiceResponse<string>>> ResetPassword(ResetPasswordRequest request)
        {
            return Ok(await _userService.ResetPassword(request));
        }
    }
}
