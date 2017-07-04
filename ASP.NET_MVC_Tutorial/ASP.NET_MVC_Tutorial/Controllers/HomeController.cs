using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_Tutorial.Controllers
{
    public class HomeController : Controller
    {
        //[Project Url]/Home/Index/
        //[Project Url]/Home/Index/[id]
        //[Project Url]/home/index/[id]?name=[name]
        //public String Index(string id)
        //{
        //    return "Id = " + id + " Name = " + Request.QueryString["name"];
        //}

        //Same as the previous method 
        //public String Index(string id, string name)
        //{
        //    return "Id = " + id + " Name = " + name;
        //}

        public ActionResult Index(string id)
        {
            ViewBag.Countries = new List<string>()
            {
                "Bangladesh", "India", "Pakistan", "USA", "England"
            };

            ViewData["Cities"] = new List<string>()
            {
                "Dhaka", "Delhi", "Lahore", "Chicago", "London"
            };

            return View();
        }


        //[Project Url]/Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[Project Url]/Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}