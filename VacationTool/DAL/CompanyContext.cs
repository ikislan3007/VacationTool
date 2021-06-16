using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;
using VacationTool.Models;

namespace VacationTool.DAL
{
    public class CompanyContext : DbContext
    {

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }
        
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Employee> Employees { get; set;}
        public DbSet<Position> Position { get; set; }
    }
}
