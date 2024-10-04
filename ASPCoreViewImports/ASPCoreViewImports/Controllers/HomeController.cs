using ASPCoreViewImports.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreViewImports.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Student> stds = new List<Student>
            {
                new Student {Id = 12, Name = "Ankur", Gender = "Male" },
                new Student {Id = 23, Name = "Dfc", Gender = "Male" },
                new Student {Id = 43, Name = "Wfc", Gender = "Female" }
            };

            return View(stds);
        }

        public IActionResult About()
        {
            List<Student> stds = new List<Student>
            {
                new Student {Id = 12, Name = "Ankur", Gender = "Male" },
                new Student {Id = 23, Name = "Dfc", Gender = "Male" },
                new Student {Id = 43, Name = "Wfc", Gender = "Female" }
            };

            return View(stds);
        }

        public IActionResult Content()
        {
            List<Student> stds = new List<Student>
            {
                new Student {Id = 12, Name = "Ankur", Gender = "Male" },
                new Student {Id = 23, Name = "Dfc", Gender = "Male" },
                new Student {Id = 43, Name = "Wfc", Gender = "Female" }
            };

            return View(stds);
        }
    }
}
