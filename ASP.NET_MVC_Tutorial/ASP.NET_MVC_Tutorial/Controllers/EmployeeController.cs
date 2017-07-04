using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC_Tutorial.Models;

namespace ASP.NET_MVC_Tutorial.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index(short departmentId = 0)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees;

            if (departmentId == 0)
            {
                employees = employeeContext.Employees.ToList();
                return View("IndexList", employees);
            }

            employees = employeeContext.Employees.Where(emp => emp.DepartmentId == departmentId).ToList();
            return View(employees);
        }

        // GET: Employee
        //[Project Url]/Employee/Details/{id}
        public ActionResult Details(short id)
        {
            //if (id == 0) return RedirectToAction("Index");

            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.Id == id);

            return View(employee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

    }
}