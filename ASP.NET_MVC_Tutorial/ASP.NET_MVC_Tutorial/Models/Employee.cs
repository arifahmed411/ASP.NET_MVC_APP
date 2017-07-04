using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_Tutorial.Models
{
    [Table("Employee")]
    public class Employee
    {
        public Int16 Id { get; set; }
        public string Name { get; set; }   
        public string Gender { get; set; }
        public string City { get; set; }
        public Int16 DepartmentId { get; set; }
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}