using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login(string login, string password)
        {
            ViewBag.Login = login;
            ViewBag.Password = password;
            return View();
        }
    }
}