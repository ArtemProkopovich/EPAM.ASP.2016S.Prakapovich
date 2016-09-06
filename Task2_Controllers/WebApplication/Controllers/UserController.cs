using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication_CustomFactory.Models;
using WebApplication_CustomFactory.Repository;

namespace WebApplication_CustomFactory.Controllers
{
    public class UserController : Controller
    {
        private Repository<User> repository;
        public UserController()
        {
            repository = new Repository<User>(new WebApplication_CustomFactory.Repository.AppContext());
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AddUser")]
        public async Task<ActionResult> AddUserPost(User user)
        {
            if (ModelState.IsValid)
            {
                await repository.Add(user);
                return RedirectToAction("UserList");
            }
            else
            {
                return View(user);
            }
        }

        [HttpGet]
        public async Task<ActionResult> UserList()
        {
            var result = await repository.List();
            return View(result);
        }

        [HttpPost]
        [ActionName("UserList")]
        public async Task<ActionResult> UserListPost()
        {
            var result = await repository.List();
            return Json(result);
        }
    }
}