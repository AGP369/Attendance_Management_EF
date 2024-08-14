using Attendance_Management_EF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Management_EF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
    }
}
