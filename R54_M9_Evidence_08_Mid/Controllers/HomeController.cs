using Microsoft.AspNetCore.Mvc;

namespace R54_M9_Evidence_08_Mid.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
