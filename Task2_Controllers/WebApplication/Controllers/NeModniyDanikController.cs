using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class NeModniyDanikController : Controller
    {
        // GET: NeModniyDanik
        public async Task<ActionResult> Danya()
        {
            NeModniyServiz serviz = new NeModniyServiz();
            var result = await serviz.getNeModniyDanik();
            return View((object)result);
        }
    }
}