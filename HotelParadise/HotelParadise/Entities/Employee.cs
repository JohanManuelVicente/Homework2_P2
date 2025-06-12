using System.ComponentModel.DataAnnotations.Schema;

namespace HotelParadise.Entities
{
    [Table("Employees")] 
    public class Employee
    {
        
        public int Id { get; set; }
       
        public string? Name {get; set;}

        public string? Position {get; set;}

        public string? Phone {get; set;}

        public DateTime Date_Admission { get; set; }
            
        public int AdministrationId { get; set; }

        //public virtual Administration? Administration { get; set; }

    }
}
