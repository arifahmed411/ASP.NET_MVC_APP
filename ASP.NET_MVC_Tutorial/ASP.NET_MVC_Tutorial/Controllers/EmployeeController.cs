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

        [HttpPost]
        public ActionResult Delete(short id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            employeeContext.DeleteEmployee(id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(short id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.Id == id);
            return View(employee);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult UpdateEmployee(short id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(e => e.Id == id);
            UpdateModel(employee, new string[] { "Id", "Gender", "City", "DepartmentId", "DateOfBirth" });
            //UpdateModel(employee, null, null, new string[] { "Name" });
            if (ModelState.IsValid)
            {
                employeeContext.UpdateEmployee(employee.Id, employee.Name, employee.Gender,
                                                employee.City, employee.DepartmentId, employee.DateOfBirth);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult UpdateEmployee([Bind(Exclude = "Name")]Employee employee)
        ////public ActionResult UpdateEmployee([Bind(Include = "Id, Gender, City, DepartmentId, DateOfBirth"]Employee employee)
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    employee.Name = employeeContext.Employees.Single(e => e.Id == employee.Id).Name;

        //    //ModelState.IsValid will return true because the property name is not bound to the employee object
        //    //The only solution is to remove the Required attribute from the Name property
        //    if (ModelState.IsValid)
        //    {
        //        employeeContext.UpdateEmployee(employee.Id, employee.Name, employee.Gender,
        //                                        employee.City, employee.DepartmentId, employee.DateOfBirth);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreateNewEmployee()
        {

            Employee employee = new Employee();
            TryUpdateModel(employee);
            if (ModelState.IsValid)
            {
                EmployeeContext employeeContext = new EmployeeContext();
                //employeeContext.Employees.Add(employee);
                //employeeContext.SaveChanges();
                employeeContext.InsertNewEmployee(employee.Name, employee.Gender, employee.City,
                                                        employee.DepartmentId, employee.DateOfBirth);
                return RedirectToAction("Index");
            }

            return View();            
        }

        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult CreateNewEmployee(Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeContext employeeContext = new EmployeeContext();
        //        //employeeContext.Employees.Add(employee);
        //        //employeeContext.SaveChanges();
        //        employeeContext.InsertNewEmployee(employee.Name, employee.Gender, employee.City,
        //                                                employee.DepartmentId, employee.DateOfBirth);
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(string name, string gender, string city, short departmentId, DateTime dateOfBirth)
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    employeeContext.InsertNewEmployee(name, gender, city,
        //                                            departmentId, dateOfBirth);

        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    string Name = formCollection["Name"];
        //    string Gender = formCollection["Gender"];
        //    string City = formCollection["City"];
        //    DateTime DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);
        //    short DepartmentId = Convert.ToInt16(formCollection["DepartmentID"]);

        //    EmployeeContext employeeContext = new EmployeeContext();
        //    employeeContext.InsertNewEmployee(Name, Gender, City,
        //                                            DepartmentId, DateOfBirth);

        //    return RedirectToAction("Index");
        //}

    }
}