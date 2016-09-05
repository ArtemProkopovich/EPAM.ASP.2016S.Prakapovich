using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using WebApplication.Controllers;

namespace WebApplication.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        private CustomControllerOctivator customControllerOctivator;

        public CustomControllerFactory(CustomControllerOctivator customControllerOctivator)
        {
            this.customControllerOctivator = customControllerOctivator;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {           
            Type controllerType;
            switch (controllerName)
            {
                case "Product":
                    controllerType = typeof(ProductController);
                    break;
                case "Customer":
                    controllerType = typeof(CustomerController);
                    break;
                default:
                    requestContext.RouteData.Values["controller"] = "Product";
                    controllerType = typeof(ProductController);
                    break;
            }
            return customControllerOctivator.Create(requestContext, controllerType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            (controller as IDisposable)?.Dispose();
        }
    }
}