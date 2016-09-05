using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Infrastructure
{
    public class CustomActionEnvoker : IActionInvoker
    {
        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (actionName != "Index") return false;
            controllerContext.HttpContext.Response.Write("This is sparta from action envoker.");
            return true;
        }
    }
}