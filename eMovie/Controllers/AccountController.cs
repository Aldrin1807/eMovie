using Microsoft.AspNetCore.Mvc;

namespace eMovie.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
