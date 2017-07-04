using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_Tutorial.Models
{
    [Table("Department")]
    public class Department
    {
        public Department()
        {
            Employees = new List<Employee>();
        }

        public Int16 Id { get; set; }
        public string Name { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}