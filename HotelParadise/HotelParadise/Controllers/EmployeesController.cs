using Microsoft.AspNetCore.Mvc;

namespace HotelParadise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("api/Employees")] Too can be this way.
    public class EmployeesController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployees()
        {

            return Ok(new List<string> { "Employee1", "Employee2", "Employee3" });
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployees(int id)
        {

            return Ok($"Employee with ID: {id}");
        }
    }
}
