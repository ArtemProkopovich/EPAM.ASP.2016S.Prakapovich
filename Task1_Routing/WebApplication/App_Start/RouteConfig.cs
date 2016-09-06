using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
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
                name: "StaticParam&CustomOptinonalSegment",
                url: "Action/{param}",
                defaults: new {controller = "Home", action = "Action", param = UrlParameter.Optional},
                namespaces: new[] {"WebApplication.Controllers"}
                );

            routes.MapRoute(
                name: "Catchall",
                url: "About/{*catchall}",
                defaults: new {controller = "Home", action = "About"},
                namespaces: new[] {"WebApplication.Controllers"}
                );

            routes.MapRoute(
                name: "NamespacePriority",
                url: "Index/json",
                defaults: new {controller = "Home", action = "Index"},
                namespaces: new[] {"WebExtension"}
                );

            routes.MapRoute(
                name: "CustomConstraint",
                url: "Home/Index/{id}",
                defaults: new {controller = "Home", action = "NotFound", id = UrlParameter.Optional},
                constraints: new {id = new EqualityRouteConstraint("404")},
                namespaces: new[] {"WebApplication.Controllers"}
                );

            routes.MapRoute(
                name: "CompoundConstraint",
                url: "login/{login}/{password}",
                defaults: new {controller = "User", action = "Login"},
                constraints:
                    new
                    {
                        login =
                            new CompoundRouteConstraint(new IRouteConstraint[]
                            {new AlphaRouteConstraint(), new MinLengthRouteConstraint(6)}),
                        password = new CompoundRouteConstraint(new IRouteConstraint[]
                        {new RegexRouteConstraint("^[A-Za-z0-9]*$"), new MinLengthRouteConstraint(6)})
                    }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional},
                constraints: new {controller = "Home|Example|User|"},
                namespaces: new[] {"WebApplication.Controllers"}
                );

            routes.MapRoute(
                name: "Error",
                url: "{*.}",
                defaults: new {controller = "Home", action = "NotFound"},
                namespaces: new[] {"WebApplication.Controllers"}
                );
        }
    }
}
