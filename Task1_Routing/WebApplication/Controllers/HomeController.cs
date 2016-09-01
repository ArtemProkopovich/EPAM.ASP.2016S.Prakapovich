using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Action(string param = "No param")
        {
            ViewBag.param = param;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}