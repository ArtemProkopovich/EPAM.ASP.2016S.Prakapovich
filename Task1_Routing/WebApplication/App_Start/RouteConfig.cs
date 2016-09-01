using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Action",
                url: "Action/{param}",
                defaults: new { controller = "Home", action = "Action", param = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "About",
                url: "About/{*catchall}",
                defaults: new { controller = "Home", action = "About"}
            );

            routes.MapRoute(
                name: "Home",
                url: "Index/json",
                defaults: new { controller = "Home", action = "Index"}
            );

            routes.MapRoute(
                name: "CustomConstraint",
                url: "Home/Index/{id}",
                defaults: new {controller = "Home", action = "NotFound", id = UrlParameter.Optional},
                constraints: new {id = new CustomRouteConstraint("404")}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "NotFound",
                url: "{*catchall}",
                defaults: new { controller = "Home", action = "NotFound"}
            );
        }
    }
}
