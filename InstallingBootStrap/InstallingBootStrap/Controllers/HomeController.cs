using Microsoft.AspNetCore.Mvc;

namespace InstallingBootStrap.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
