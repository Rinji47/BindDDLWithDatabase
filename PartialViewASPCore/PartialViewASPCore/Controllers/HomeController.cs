using Microsoft.AspNetCore.Mvc;
using PartialViewASPCore.Models;
using System.Diagnostics;

namespace PartialViewASPCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Products()
        {
            List<Product> products = new List<Product>()
            {
                new Product(){ Id = 101, Name = "Black Jacket", Description = "Black Jacket and a man", Price = 3000, Image="~/Images/BlackJacket.jpg"},
                new Product(){ Id = 102, Name = "Bike", Description = "Hunter 350", Price = 475000, Image="~/Images/Bike.jpg"},
                new Product(){ Id = 103, Name = "Mouse", Description = "Mouse with a joint", Price = 5000, Image="~/Images/Mouse.jpg"}
            };
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
