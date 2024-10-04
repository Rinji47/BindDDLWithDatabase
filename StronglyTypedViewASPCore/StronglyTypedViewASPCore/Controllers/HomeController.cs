using Microsoft.AspNetCore.Mvc;
using StronglyTypedViewASPCore.Models;
using System.Diagnostics;

namespace StronglyTypedViewASPCore.Controllers
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
            //Employee obj = new Employee()
            //{
            //    EmpId = 101,
            //    EmpName = "Ankur",
            //    Designation = "CEO",
            //    Salary = 2121313313
            //};

            var myEmployees = new List<Employee>
            {
                new Employee() {EmpId = 101, EmpName = "Ankur", Designation = "CEO", Salary = 100000000},
                new Employee() {EmpId = 102, EmpName = "Ybin", Designation = "CEO", Salary = 100000000},
                new Employee() {EmpId = 103, EmpName = "HYob", Designation = "CEO", Salary = 100000000},
                new Employee() {EmpId = 104, EmpName = "Ivmn", Designation = "CEO", Salary = 100000000},
                new Employee() {EmpId = 105, EmpName = "Yimn", Designation = "CEO", Salary = 100000000}
            };

            return View(myEmployees);
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
