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
        private List<Administration> _Departments;
        public EmployeesController()
        {
            _Departments = new List<Administration>
            {
                new Administration { Id = 1, Department = "Administración", Email = "admin@hotel.com", Phone = "809-000-0000" },
                new Administration { Id = 2, Department = "Recursos Humanos", Email = "rh@hotel.com", Phone = "809-111-1111" }
            };


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

            var dept = _Departments.FirstOrDefault(d => d.Id == employee.DepartmentId);
            if (dept == null)
            {
                return BadRequest("Departamento inválido");
            }

            /*Id = _Employees.Max (e => e.Id) + 1; */     // Funciona, pero es pesada
            employee.Id = _Employees.Count + 1;
            employee.Date_Admission = DateTime.Now;
            employee.Department = dept;
            _Employees.Add(employee);
            return Ok(_Employees);
        }

        /*PUT // Way Classic
        //[HttpPut]

        //public IActionResult PutEmployees([FromBody] Employee employee)
        //{
        //    if (employee.Position == null)
        //    {
        //        return BadRequest("Cargo es nulo o ID no coincide");
        //    }

        //    var existingEmployee = _Employees.FirstOrDefault(s=> s.Id == employee.Id);
        //    if(existingEmployee == null)
        //    {
        //        return NotFound($" Empleado con ID {employee.Id} no fue encontrado");
        //    }
          var dept = _Departments.FirstOrDefault(d => d.Id == employee.DepartmentId);
            if (dept == null)
            {
                return BadRequest("Departamento inválido");
            }

        //    existingEmployee.Name = employee.Name;
        //    existingEmployee.Date_Admission = DateTime.Now;
        //    existingEmployee.Position = employee.Position;
        //    existingEmployee.DepartmentId = employee.DepartmentId;
        //    existingEmployee.Phone = employee.Phone;
        existingEmployee.DepartmentId = employee.DepartmentId;
            existingEmployee.Department = dept;

        //    //return Ok(existingEmployee);
        //    return Ok(_Employees);

        //}*/   // Way Classic

        //PUT // Way Standart
        [HttpPut("{id}")]
        public IActionResult PutEmployees(int id, [FromBody] Employee employee)
        {
            if (employee.Position == null || employee.Id != id)
            {
                return BadRequest("Cargo es nulo o ID no coincide");
            }

            var existingEmployee = _Employees.FirstOrDefault(s => s.Id == employee.Id);
            if (existingEmployee == null)
            {
                return NotFound($" Empleado con ID {employee.Id} no fue encontrado");
            }

            var dept = _Departments.FirstOrDefault(d => d.Id == employee.DepartmentId);
            if (dept == null)
            {
                return BadRequest("Departamento inválido");
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Date_Admission = DateTime.Now;
            existingEmployee.Position = employee.Position;
            existingEmployee.DepartmentId = employee.DepartmentId;
            existingEmployee.Phone = employee.Phone;
            existingEmployee.DepartmentId = employee.DepartmentId;
            existingEmployee.Department = dept;
            //return Ok(existingEmployee);
            return Ok(_Employees);

        } // Way Standart

        //DELETE
        [HttpDelete("{id}")]

        public IActionResult DeleteEmployees(int id)
        {
            var employee = _Employees.FirstOrDefault(p => p.Id == id);
            if(employee == null)
            {
                return NotFound($"Empleado con ID: {id} no fue encontrado");
            }

            _Employees.Remove(employee);
            //return NoContent();
            return Ok(_Employees);
        }
    }
}
