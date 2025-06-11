namespace HotelParadise.Entities
{
    /* [Table("Employees")] */// eso es para el mapeo que coincida con el nombre en la DB
    public class Administration
    {
        public int Id { get; set; }
        
        public string Department { get; set; }

        public  string? Email { get; set; }

        public string? Phone { get; set; }

        public virtual ICollection<Employee> Employees { get;   set; }
    }
}
