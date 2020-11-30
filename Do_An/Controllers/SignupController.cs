using Do_An.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            if(ModelState.IsValid)
            {
                if(!new AccountModel().CheckExist(model.SDT))
                {
                    if (model.Passowrd == model.ReenterPassword)
                    {
                        bool check = new AccountModel().Signup(model.SDT, model.Passowrd, model.HoTen, model.DiaChi, model.Email);
                        if (check)
                        {
                            ModelState.AddModelError("", "Đăng ký thành công");
                            return View("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Đăng ký thất bại");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Xác nhận mật khẩu không đúng");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Số điện thoại đã tồn tại");
                }
            }      
            return View(model);
        }
    }
}