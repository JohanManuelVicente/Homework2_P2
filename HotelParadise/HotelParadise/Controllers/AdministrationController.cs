//using Microsoft.AspNetCore.Mvc;
//using HotelParadise.Entities;
//using Microsoft.AspNetCore.Http.HttpResults;

//namespace HotelParadise.Controllers
//{
//    public class AdministrationController
//    {
//        private List<Administration> _Departments = new List<Administration>
//{
//    new Administration { Id = 1, Department = "Administración", Email = "admin@hotel.com", Phone = "809-000-0000" },
//    new Administration { Id = 2, Department = "Recursos Humanos", Email = "rh@hotel.com", Phone = "809-111-1111" }
//};

//        [HttpPost]
//        public IActionResult PosEmployees([FromBody] Employee employee)
//        {
//            if (employee.Position == null)
//            {
//                return BadRequest($"Cargo no puede ser nulo");
//            }

//            var dept = _Departments.FirstOrDefault(d => d.Id == employee.DepartmentId);
//            if (dept == null)
//            {
//                return BadRequest("Departamento inválido");
//            }

//            employee.Id = _Employees.Count + 1;
//            employee.Date_Admission = DateTime.Now;
//            employee.Department = dept;

//            _Employees.Add(employee);
//            return Ok(_Employees);
//        }

//    }

