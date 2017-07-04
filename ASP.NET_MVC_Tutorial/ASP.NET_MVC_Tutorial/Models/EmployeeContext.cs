using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_Tutorial.Models
{
    public class EmployeeContext : DbContext
    {
        //public EmployeeContext()
        //{
        //    Configuration.ProxyCreationEnabled = false;
        //    Configuration.LazyLoadingEnabled = false;
        //}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Department>()
        //        .Property(e => e.Name)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Department>()
        //        .HasMany(e => e.Employees)
        //        .WithRequired(e => e.Department)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Employee>()
        //        .Property(e => e.Name)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Employee>()
        //        .Property(e => e.Gender)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Employee>()
        //        .Property(e => e.City)
        //        .IsUnicode(false);
        //}

    }

}