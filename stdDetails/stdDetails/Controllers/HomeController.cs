using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stdDetails.Models;
using System.Data.Common;
using System.Diagnostics;

namespace stdDetails.Controllers
{
	public class HomeController : Controller
	{

		//private readonly ILogger<HomeController> _logger;

		//public HomeController(ILogger<HomeController> logger)
		//{
		//    _logger = logger;
		//}

		private readonly StudentDBContext DBobj;
		public HomeController(StudentDBContext DBobj)
		{
			this.DBobj = DBobj;
		}

		public IActionResult Index()
		{
			var stdsData = DBobj.SecondStudents.ToList();
			return View(stdsData);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Students stds)
		{
			if (ModelState.IsValid)
			{
				await DBobj.SecondStudents.AddAsync(stds);
				await DBobj.SaveChangesAsync();
				TempData["InsertSuccess"] = "Data has been inserted sucessfully";
				return RedirectToAction("Index", "Home");
			}
			return View(stds);
		}

		public async Task<IActionResult> Details(int id)
		{
			if (id == null || DBobj == null)
			{
				return NotFound();
			}
			var stdData = await DBobj.SecondStudents.FirstOrDefaultAsync(x => x.Id == id);

			if (stdData == null)
			{
				return NotFound();
			}
			return View(stdData);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || DBobj == null)
			{
				return NotFound();
			}

			var stdData = await DBobj.SecondStudents.FindAsync(id);
			if (stdData == null)
			{
				return NotFound();
			}

			return View(stdData);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int? id, Students stds)
		{
			if (id != stds.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				DBobj.SecondStudents.Update(stds);
				await DBobj.SaveChangesAsync();
				TempData["UpdatedSuccess"] = "Data has been updated sucessfully";
				return RedirectToAction("Index", "Home");
			}
			return View(stds);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || DBobj == null)
			{
				return NotFound();
			}
			var stdData = await DBobj.SecondStudents.FirstOrDefaultAsync(x => x.Id == id);

			if (stdData == null)
			{
				return NotFound();
			}
			return View(stdData);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> ConfirmedDelete(int? id)
		{
			var stdsData = await DBobj.SecondStudents.FindAsync(id);
			if(stdsData != null)
			{
				DBobj.SecondStudents.Remove(stdsData);
			}
			await DBobj.SaveChangesAsync();
			TempData["DeletedSuccess"] = "Data has been deleted sucessfully";
			return RedirectToAction("Index", "Home");
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
