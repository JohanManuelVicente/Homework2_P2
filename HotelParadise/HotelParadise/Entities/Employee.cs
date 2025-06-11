using System.ComponentModel.DataAnnotations.Schema;

namespace HotelParadise.Entities
{
   /* [Table("Employees")] */// eso es para el mapeo que coincida con el nombre en la DB
    public class Employee
    {
        //[Column("Id_Employees")]
        public int Id { get; set; }
        //[Column("Name_Employees")]
        public string? Name {get; set;}

        public string Position {get; set;}

        public string? Phone {get; set;}

        public DateTime Date_Admission { get; set; }

        public int DepartmentId { get; set; }

        public virtual Administration? Department { get; set; }

    }
}
