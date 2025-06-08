using Microsoft.AspNetCore.Mvc;
using HotelParadise.Entities;

namespace HotelParadise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("api/Employees")] Too can be this way.
    public class EmployeesController: ControllerBase
    {


        private List<HotelParadise.Entities.Employee> _Employees;
        public EmployeesController()
        {
            _Employees = new List<HotelParadise.Entities.Employee>();
            _Employees.Add(new Employee { Id=1, Name = "Empleado1", Position="Administrador", Phone="809-821-5154", Date_Admission=DateTime.Now });
            _Employees.Add(new Employee { Id = 2, Name = "Empleado2", Position = "Cajero", Phone = "829-821-5154", Date_Admission = DateTime.Now });
            _Employees.Add(new Employee { Id = 3, Name = "Empleado3", Position = "Tecnico", Phone = "849-821-5154", Date_Admission = DateTime.Now });
        }
        //GET
        [HttpGet]
        public IActionResult GetEmployees()
        {

            return Ok(_Employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployees(int id)
        {
            //var Employee = new Employee();*/

            //foreach (var item in _Employees)
            //{
            //    if (item.Id == id) 
            //    {

            //        Employee = item;
            //        //return Ok(Employee);
            //        break;

            //    }
            //}


            //Employee = _Employees.FirstOrDefault(s => s.Id == id); The Way more used


            var Employee = _Employees.Where(e => e.Id == id).FirstOrDefault();
            if (Employee == null)
            {
                return NotFound($"Empleado con ID {id} no fue encontrado");
            }

            return Ok(Employee);
        }


        //POST
        [HttpPost]

        public IActionResult PosEmployees(int Id, string Name, string Position, string Phone, DateTime Date_Admission)
        {

        return BadRequest(); 
        }

    }
}
