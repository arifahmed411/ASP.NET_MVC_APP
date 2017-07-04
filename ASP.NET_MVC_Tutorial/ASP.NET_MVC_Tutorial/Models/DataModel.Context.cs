﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP.NET_MVC_Tutorial.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    
        public virtual int InsertNewEmployee(string name, string gender, string city, Nullable<short> departmentId, Nullable<System.DateTime> dateOfBirth)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var departmentIdParameter = departmentId.HasValue ?
                new ObjectParameter("DepartmentId", departmentId) :
                new ObjectParameter("DepartmentId", typeof(short));
    
            var dateOfBirthParameter = dateOfBirth.HasValue ?
                new ObjectParameter("DateOfBirth", dateOfBirth) :
                new ObjectParameter("DateOfBirth", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertNewEmployee", nameParameter, genderParameter, cityParameter, departmentIdParameter, dateOfBirthParameter);
        }
    }
}
