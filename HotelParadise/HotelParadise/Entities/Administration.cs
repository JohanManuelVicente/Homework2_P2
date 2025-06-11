using System.ComponentModel.DataAnnotations.Schema;

namespace HotelParadise.Entities
{
    [Table("Administration")]
    public class Administration
    {
        public int Id { get; set; }
        
        public string? Department { get; set; }

        public  string? Email { get; set; }

        public string? Phone { get; set; }

        public virtual ICollection<Employee> Employees { get;   set; }
    }
}
