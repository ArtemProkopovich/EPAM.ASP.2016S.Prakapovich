using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using WebApplication_CustomFactory.Controllers;

namespace WebApplication_CustomFactory.Infrastructure
{
    public class CustomControllerFactory : DefaultControllerFactory
    {

        protected override SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == typeof(HomeController))
            {
                return SessionStateBehavior.Disabled;
            }
            return base.GetControllerSessionBehavior(requestContext, controllerType);
        }

        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            if (string.Compare(controllerName, "Customer", StringComparison.OrdinalIgnoreCase) == 0)
                return typeof(UserController);
            return base.GetControllerType(requestContext, controllerName);
        }
    }
}