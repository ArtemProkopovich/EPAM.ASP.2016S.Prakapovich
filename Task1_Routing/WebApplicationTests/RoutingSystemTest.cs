using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Machine.Specifications;
using MvcContrib.TestHelper;
using WebApplication;
using WebExtension;
using It = Machine.Specifications.It;

namespace WebApplicationTests
{
    [Subject("Routing")]
    public class RoutingSystemTest
    {
        private Establish context = () => {
            routes = RouteTable.Routes;
            RouteConfig.RegisterRoutes(routes);
        };
        
        private Because of = () => {
        };

        private It shouldRouteToWebExtensionHomeIndex = () =>
        {
            "~/Index/json".Route().ShouldMapTo<WebExtension.HomeController>(e => e.Index());
        };

        private It shouldRouteToHomeActionWithParam = () =>
        {
            "~/Action/1".Route().ShouldMapTo<WebApplication.Controllers.HomeController>(e => e.Action("1"));
        };

        private It shouldBeRouteToHomeAbout = () =>
        {
            "~/About".Route().ShouldMapTo<WebApplication.Controllers.HomeController>(e => e.About());
            "~/About/section1".Route().ShouldMapTo<WebApplication.Controllers.HomeController>(e => e.About());
            "~/About/section1/section2".Route().ShouldMapTo<WebApplication.Controllers.HomeController>(e => e.About());
        };

        private It shouldRouteToHomeOrNotFoundDueToParam = () =>
        {
            "~/Home/Index/404".Route().ShouldMapTo<WebApplication.Controllers.HomeController>(e => e.NotFound());
            "~/Home/Index/405".Route().ShouldMapTo<WebApplication.Controllers.HomeController>(e => e.Index());
        };

        private It shouldRouteDueToCompoundConstraint = () =>
        {
            "~/login/AAAAAA/AAA111".Route()
                .ShouldMapTo<WebApplication.Controllers.UserController>(e => e.Login("AAAAAA", "AAA111"));
            "~/login/AAAAA/AAA111".ShouldMapTo<WebApplication.Controllers.HomeController>(e => e.NotFound());
            "~/login/AAAAAA/AAA11".ShouldMapTo<WebApplication.Controllers.HomeController>(e => e.NotFound());
            "~/login/AAAAAA/AAA11@@".ShouldMapTo<WebApplication.Controllers.HomeController>(e => e.NotFound());
        };

        private It shouldRouteToDefaultPage = () =>
        {
            "~/".Route().ShouldMapTo<WebApplication.Controllers.HomeController>(e => e.Index());
        };

        private It shouldRouteToNotFoundPage = () =>
        {
            "~/bla-bla/bla".Route().ShouldMapTo<WebApplication.Controllers.HomeController>(e => e.NotFound());
        };

        static RouteCollection routes;
    }
}
