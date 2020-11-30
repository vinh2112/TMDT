using Do_An.Code;
using Do_An.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Do_An.Frameworks;

namespace Do_An.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Index(USER model)
        {
            //var result = new AccountModel().Login(model.Username, model.Password);
            if (Membership.ValidateUser(model.UserN,model.PassW) && ModelState.IsValid && model.UserN == "admin")
            {
                //SessionHelper.SetSession(new UserSession() { UserName = model.Username });
                FormsAuthentication.SetAuthCookie(model.UserN,true);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                if (Membership.ValidateUser(model.UserN, model.PassW) && ModelState.IsValid)
                {
                    //SessionHelper.SetSession(new UserSession() { UserName = model.Username });
                    return RedirectToAction("Index", "Home", new { area = "Customer" });
                }
                else
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng !!");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}