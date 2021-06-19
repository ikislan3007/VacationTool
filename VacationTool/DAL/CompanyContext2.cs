using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;
using VacationTool.Models;

namespace VacationTool.DAL
{
    public class CompanyContext2 : DbContext
    {

        public CompanyContext2(DbContextOptions<CompanyContext2> options) : base(options)
        {
        }
        
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Employee> Employees { get; set;}
        public DbSet<Position> Positions { get; set; }
    }
}
