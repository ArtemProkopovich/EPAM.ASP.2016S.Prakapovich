﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication_CustomFactory.Controllers;

namespace WebApplication_CustomFactory.Infrastructure
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            return base.CreateController(requestContext, controllerName);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return base.GetControllerInstance(requestContext, controllerType);
        }

        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            if (string.Compare(controllerName, "Customer", StringComparison.OrdinalIgnoreCase) == 0)
                return typeof(UserController);
            return base.GetControllerType(requestContext, controllerName);
        }
    }
}