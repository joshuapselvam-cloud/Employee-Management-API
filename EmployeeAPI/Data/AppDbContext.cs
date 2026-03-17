using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;

namespace EmployeeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
