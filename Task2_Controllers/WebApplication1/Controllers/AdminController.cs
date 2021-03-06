﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication.Infrastructure;
using WebApplication.Models;
using WebApplication_CustomFactory.Repository;

namespace WebApplication_CustomFactory.Controllers
{
    public class AdminController : Controller
    {

        private Repository<User> repository;

        public AdminController()
        {
            this.ActionInvoker = new CustomActionInvoker();
            repository = new Repository<User>(new WebApplication_CustomFactory.Repository.AppContext());
        }

        // GET: Admin
        public ActionResult Index()
        {
            var result = repository.List();
            return View(result.Result);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            var result = repository.Get(id);
            return View(result.Result);
        }

        // GET: Admin/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var result =  repository.Get(id);
            return View(result.Result);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                await repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                var result = repository.Get(id);
                return View(result.Result);
            }
        }
    }
}
