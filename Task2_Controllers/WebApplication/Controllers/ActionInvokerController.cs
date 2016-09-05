using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Infrastructure;

namespace WebApplication.Controllers
{
    public class ActionInvokerController : Controller
    {
        public ActionInvokerController()
        {
            this.ActionInvoker = new CustomActionEnvoker();
        }

        // GET: ActionInvoker
        public ActionResult Index()
        {
            return View();
        }

        // GET: ActionInvoker
        [CustonSillactorAtrebut]
        public ActionResult Some()
        {
            return View();
        }
    }
}