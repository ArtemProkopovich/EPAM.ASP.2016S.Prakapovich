using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View("Result", new Result()
            {
                ControllerName = "Customer",
                ActionName = "Index"
            });
        }

        public ActionResult List()
        {
            return View("Result", new Result()
            {
                ControllerName = "Customer",
                ActionName = "List"
            });
        }
    }
}