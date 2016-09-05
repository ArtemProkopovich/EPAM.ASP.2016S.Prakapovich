using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [RoutePrefix("AttributeRoute")]
    public class ExampleController : Controller
    {
        // GET: Example
        [Route("~/Attribute/Main")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("DoWork/{param:length(6)}")]
        public ActionResult Action(string param)
        {
            ViewBag.Text = param;
            return View();
        }
    }
}