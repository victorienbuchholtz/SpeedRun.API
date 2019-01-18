using Microsoft.AspNetCore.Mvc;

namespace SpeedRun.API.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}