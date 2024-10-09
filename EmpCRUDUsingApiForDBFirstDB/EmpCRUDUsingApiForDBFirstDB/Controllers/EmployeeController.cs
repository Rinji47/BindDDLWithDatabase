using EmpCRUDUsingApiForDBFirstDB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;

namespace EmpCRUDUsingApiForDBFirstDB.Controllers
{
    public class EmployeeController : Controller
    {
        private string url = "https://localhost:7146/api/Employee/";
        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Employee>>(result);
                if (data != null)
                {
                    employees = data;
                }

            }

            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            var data = JsonConvert.SerializeObject(emp);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["InsertSuccess"] = "Employee Data Inserted Sucessfully!";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = new Employee();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Employee>(result);
                if (data != null)
                {
                    employee = data;
                }
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var data = JsonConvert.SerializeObject(employee);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage respond = client.PutAsync(url + employee.id, content).Result;
            if (respond.IsSuccessStatusCode)
            {
                TempData["UpdateSuccess"] = "Employee Data Updated Sucessfully!";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee employee = new Employee();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Employee>(result);
                if (data != null)
                {
                    employee = data;
                }
            }

            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee employee = new Employee();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Employee>(result);
                if (data != null)
                {
                    employee = data;
                }
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
			{
				TempData["DeleteSuccess"] = "Employee Data Deleted Sucessfully!";
				return RedirectToAction("Index");
			}

			return View();
		}
    }
}