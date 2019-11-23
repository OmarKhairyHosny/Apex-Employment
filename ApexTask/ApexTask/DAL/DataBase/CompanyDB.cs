using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApexTask.DAL.DataBase
{
    public class CompanyDB:DbContext
    {
        public CompanyDB()
        {

        }
        public CompanyDB(DbContextOptions options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(g => g.Employees)
                .HasForeignKey(s => s.DepartmentId);
            modelBuilder.Entity<Task>()
           .HasOne(e => e.Employee)
           .WithMany(g => g.Tasks)
           .HasForeignKey(s => s.EmployeeId);
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
       
        
    }
}
