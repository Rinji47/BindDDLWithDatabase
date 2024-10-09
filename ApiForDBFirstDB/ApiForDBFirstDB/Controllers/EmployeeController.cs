using ApiForDBFirstDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiForDBFirstDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CodeFirstDbContext context;

        public EmployeeController(CodeFirstDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var datas = await context.Employees.ToListAsync();
            return Ok(datas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            if(id != employee.Id)
            {
                return BadRequest();
            }

            context.Entry(employee).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var emp = await context.Employees.FindAsync(id);
            if(emp == null)
            {
                return NotFound();
            }

            context.Employees.Remove(emp);
            await context.SaveChangesAsync();
            return Ok(emp);

        }
    }
}
