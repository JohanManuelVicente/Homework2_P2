using Microsoft.AspNetCore.Mvc;
using HotelParadise.Entities;
using HotelParadise.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace HotelParadise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("api/Employees")] Too can be this way.
    public class EmployeesController: ControllerBase
    {


        //private List<Employee> _Employees;
        //private List<Administration> _Administration;

        private readonly HotelParadiseDBContext _context;
        public EmployeesController(HotelParadiseDBContext context)
        {
            /*_Departments = new List<Administration>
            //{
            //    new Administration { Id = 1, Department = "Administración", Email = "admin@hotel.com", Phone = "809-000-0000" },
            //    new Administration { Id = 2, Department = "Recursos Humanos", Email = "rh@hotel.com", Phone = "809-111-1111" }
            //};


        //    _Employees = new List<Employee>();
        //    _Employees.Add(new Employee { Id=1, Name = "Empleado1", Position="Administrador", Phone="809-821-5154", Date_Admission=DateTime.Now });
        //    _Employees.Add(new Employee { Id = 2, Name = "Empleado2", Position = "Cajero", Phone = "829-821-5154", Date_Admission = DateTime.Now });
        //    _Employees.Add(new Employee { Id = 3, Name = "Empleado3", Position = "Tecnico", Phone = "849-821-5154", Date_Admission = DateTime.Now });
        */

            _context = context;
            //_Employees = context.Employees.ToList();
            //_Administration = context.Administration.ToList();
        }
        //GET
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var Employees = _context.Employees.ToList();
            return Ok(Employees);
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


            var Employee = _context.Employees.Where(e => e.Id == id).FirstOrDefault();
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

            var dept = _context.Administration.FirstOrDefault(d => d.Id == employee.AdministrationId);
            if (dept == null)
            {
                return BadRequest("Departamento inválido");
            }

            /*Id = _Employees.Max (e => e.Id) + 1; */     // Funciona, pero es pesada
           
            employee.Date_Admission = DateTime.Now;
            //employee.Department = dept;
            _context.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
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

            var existingEmployee = _context.Employees.FirstOrDefault(s => s.Id == employee.Id);
            if (existingEmployee == null)
            {
                return NotFound($" Empleado con ID {employee.Id} no fue encontrado");
            }

            var dept = _context.Administration.FirstOrDefault(d => d.Id == employee.AdministrationId);
            if (dept == null)
            {
                return BadRequest("Departamento inválido");
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Date_Admission = DateTime.Now;
            existingEmployee.Position = employee.Position;
            existingEmployee.AdministrationId = employee.AdministrationId;
            existingEmployee.Phone = employee.Phone;
            existingEmployee.AdministrationId = employee.AdministrationId;
            //existingEmployee.Department = dept;
            _context.Employees.Update(existingEmployee);
            _context.SaveChanges();
            //return Ok(existingEmployee);
            return Ok(existingEmployee);

        } // Way Standart

        //DELETE
        [HttpDelete("{id}")]

        public IActionResult DeleteEmployees(int id)
        {
            var employee = _context.Employees.FirstOrDefault(p => p.Id == id);
            if(employee == null)
            {
                return NotFound($"Empleado con ID: {id} no fue encontrado");
            }

            _context.Employees.Remove(employee);
            return NoContent();
            
        }
    }
}
