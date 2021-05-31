using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using VacationTool.Models;

namespace VacationTool.DAL
{
    public class CompanyContext : DbContext
    {

        public CompanyContext() : base("CompanyContext")
        {
        }
        
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Position { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
