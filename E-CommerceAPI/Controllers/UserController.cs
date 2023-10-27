using E_CommerceAPI.Models;
using E_CommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterRequest request)
        {
            return Ok(await _userService.RegisterUser(request));
        }
    }
}
