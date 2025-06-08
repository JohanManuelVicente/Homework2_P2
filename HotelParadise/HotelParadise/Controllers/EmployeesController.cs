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

        public IActionResult PosEmployees([FromBody] Employee employee)
        {
            if (employee.Position == null)
            {
                return BadRequest($"Cargo no puede ser nulo");
            }

            /*Id = _Employees.Max (e => e.Id) + 1; */     // Funciona, pero es pesada
            employee.Id = _Employees.Count + 1;
            employee.Date_Admission = DateTime.Now;
            _Employees.Add(employee);
            return Ok(_Employees);
        }

        //PUT
        [HttpPut]

        public IActionResult PutEmployees([FromBody] Employee employee)
        {
            if (employee.Position == null || employee.Id != employee.Id)
            {
                return BadRequest("Cargo es nula o ID no coincide");
            }

            var existingEmployee = _Employees.FirstOrDefault(s=> s.Id == employee.Id);
            if(existingEmployee == null)
            {
                return NotFound($" Empleado con ID {employee.Id} no fue encontrado");
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Date_Admission = DateTime.Now;
            //return Ok(existingEmployee);
            return Ok(_Employees);

        }

        //DELETE
    }
}
