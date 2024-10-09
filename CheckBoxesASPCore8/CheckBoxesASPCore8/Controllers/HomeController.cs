using CheckBoxesASPCore8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CheckBoxesASPCore8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

		//     public IActionResult Index()
		//     {
		//         var model = new ViewModel()
		//         {
		//             AcceptTerms = false,
		//             Text = "I Accept The Terms"
		//};
		//         return View(model);
		//     }

		public IActionResult Index()
		{
			var model = new ViewModel()
			{
				checkBoxes = new List<CheckBoxOption>
				{
					 new CheckBoxOption()
					 {
						 isChecked = true,
						 text = "Cricket",
						 value = "Cricket"
					 },
					 new CheckBoxOption()
					 {
						 isChecked = false,
						 text = "Football",
						 value = "Football"
					 },
					 new CheckBoxOption()
					 {
						 isChecked = false,
						 text = "Hockey",
						 value = "Hockey"
					 },
				}
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult Index(ViewModel data)
		{
			return View();
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
