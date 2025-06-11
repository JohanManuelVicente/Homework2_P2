using Microsoft.EntityFrameworkCore;
using HotelParadise.Entities;

namespace HotelParadise.Data
{
    public class HotelParadiseDBContext : DbContext
    {
        public HotelParadiseDBContext(DbContextOptions<HotelParadiseDBContext> options) : base(options) { } 

        public DbSet<Administration> Administration { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
