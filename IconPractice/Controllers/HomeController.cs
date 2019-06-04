using Microsoft.AspNetCore.Mvc;

namespace IconPractice.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}