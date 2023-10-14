using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
