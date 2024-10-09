using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewModelASPCore8.Models;

namespace ViewModelASPCore8.Controllers
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
            List<Student> students = new List<Student>
            {
                new Student{Id = 1, Name = "Ankur", Gender = "Male", Standard = 14},
                new Student{Id = 2, Name = "Biswas", Gender = "Male", Standard = 14},
                new Student{Id = 3, Name = "Yasu", Gender = "Female", Standard = 12}
            };

            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher{Id = 1, Name = "Yesh", Qualification = "Janitor", Salary = 14000},
                new Teacher{Id = 2, Name = "Blash", Qualification = "Class Teacher", Salary = 40000},
                new Teacher {Id = 3, Name = "Yank", Qualification = "Teacher", Salary = 30000}
            };

            SchoolViewModel svm = new SchoolViewModel
            {
                //myStudents = new List<Student>
                //{
                //    new Student{Id = 1, Name = "Ankur", Gender = "Male", Standard = 14},
                //    new Student{Id = 2, Name = "Biswas", Gender = "Male", Standard = 14},
                //    new Student{Id = 3, Name = "Yasu", Gender = "Female", Standard = 12}
                //},
                //myTeachers = new List<Teacher>
                //{
                //    new Teacher{Id = 1, Name = "Yesh", Qualification = "Janitor", Salary = 14000},
                //    new Teacher{Id = 2, Name = "Blash", Qualification = "Class Teacher", Salary = 40000},
                //    new Teacher {Id = 3, Name = "Yank", Qualification = "Teacher", Salary = 30000}
                //}

                myStudents = students,
                myTeachers = teachers
            };

            return View(svm);
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
