using AnimeLike.Areas.Admin.Code;
using AnimeLike.Areas.Admin.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimeLike.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login

            [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new AccountModel().Login(model.UserName, model.Password);
            if (result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
                return RedirectToAction("Index", "Manager");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is incorrect.");
            }
            return View(model);
        }
    }
}