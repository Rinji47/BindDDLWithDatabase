using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegisterAndLogin.Models;
using System.Diagnostics;

namespace RegisterAndLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly LogInAndSignUpContext context;

        public HomeController(LogInAndSignUpContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {


            List<SelectListItem> Gender = new()
            {
                new SelectListItem{Value = "Male", Text = "Male"},
                new SelectListItem{Value = "Female", Text = "Female"}
            };
            ViewBag.Gender = Gender;

            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Dashboard");
            }

            
        }

        [HttpPost]
        public async Task<IActionResult> Register(LogInAndSignUp user)
        {
            ViewBag.Gender = new List<SelectListItem>
            {
                new SelectListItem{Value = "Male", Text = "Male"},
                new SelectListItem{Value = "Female", Text = "Female"}
            };

            var emailExists = context.LogInAndSignUps.Where(x => x.Email == user.Email).FirstOrDefault();
            if(emailExists != null)
            {
				ModelState.AddModelError("Email", "Email already registered");
				return View(user);
			}

            if (ModelState.IsValid)
            {
                await context.LogInAndSignUps.AddAsync(user);
                await context.SaveChangesAsync();
                TempData["Success"] = "Account Registered successfully!";
                return RedirectToAction("Login");
            }


            return View(user);
        }

        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LogInAndSignUp user)
        {
            var logUser = context.LogInAndSignUps.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (logUser != null)
            {
                HttpContext.Session.SetString("UserSession", logUser.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login Failed";
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            var userEmail = HttpContext.Session.GetString("UserSession");
            if (userEmail != null) 
            {
                var user = context.LogInAndSignUps.Where(x => x.Email == userEmail).FirstOrDefault();
                if (user != null) 
                {
                    return View(user);
                }
            }
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            if(HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");
            }
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
