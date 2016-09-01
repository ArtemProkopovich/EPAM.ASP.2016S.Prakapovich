using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebExtension
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Json(new {value = "jsonIndex"});
        }
    }
}
