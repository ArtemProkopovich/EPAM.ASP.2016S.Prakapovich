using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace WebApplication.Routing
{
    public class CustomRouteConstraint:IRouteConstraint
    {
        private readonly string param;
        public CustomRouteConstraint(string param)
        {
            this.param = param;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            var segment = values[parameterName] as string;
            return segment != null && segment == param;
        }
    }
}