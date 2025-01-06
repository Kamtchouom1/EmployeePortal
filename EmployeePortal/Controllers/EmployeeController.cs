using EmployeePortal.Models;
using EmployeePortal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository emp;

        public EmployeeController(EmployeeRepository emp)
        {
            this.emp = emp;
        }

        //Read
        [HttpGet]
        public async Task<ActionResult> EmployeeList()
        {
            var allEmployees = await emp.GetAllEmployees();
            return Ok(allEmployees);
        }

        //Create
        [HttpPost]
        public async Task<ActionResult> addEmployee(Employee vm)
        {
            await emp.SaveEmployee(vm);
            return Ok(vm);
        }

        //update
        [HttpPut("{id}")]
        public async Task<ActionResult> updateEmployee(int id, [FromBody] Employee vm)
        {
            await emp.updateEmployee(id, vm);
            return Ok(vm);
        }

        //delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteEmployee(int id)
        {
            await emp.DeleteEmployee(id);
            return Ok();
        }
    }
}
