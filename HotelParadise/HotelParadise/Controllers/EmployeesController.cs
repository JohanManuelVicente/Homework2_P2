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


    

        private readonly HotelParadiseDBContext _context;
        public EmployeesController(HotelParadiseDBContext context)
        {

            _context = context;
     
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

     

        //PUT // Way Standart
        [HttpPut("{id}")]
        public IActionResult PutEmployees(int id, [FromBody] Employee employee)
        {
            if (employee.Position == null )
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
            _context.SaveChanges();
            return NoContent();
            


        }
    }
}
