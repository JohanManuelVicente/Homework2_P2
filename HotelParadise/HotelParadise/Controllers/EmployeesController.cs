using Microsoft.AspNetCore.Mvc;

namespace HotelParadise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("api/Employees")] Too can be this way.
    public class EmployeesController: ControllerBase
    {


        List<HotelParadise.Entities.Employee> Employees;
        public EmployeesController()
        {
            Employees = new List<HotelParadise.Entities.Employee>();
            Employees.Add(new HotelParadise.Entities.Employee { Id=1, Name = "Empleado1", position="Administrador", Phone="809-821-5154", Date_Admission=DateTime.Today});
            Employees.Add(new HotelParadise.Entities.Employee { Id = 2, Name = "Empleado2", position = "Cajero", Phone = "829-821-5154", Date_Admission = DateTime.Today });
            Employees.Add(new HotelParadise.Entities.Employee { Id = 3, Name = "Empleado3", position = "Tecnico", Phone = "849-821-5154", Date_Admission = DateTime.Today });
        }

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
