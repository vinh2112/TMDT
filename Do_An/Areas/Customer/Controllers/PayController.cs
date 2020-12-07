using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An.Frameworks;

namespace Do_An.Areas.Customer.Controllers
{
    public class PayController : Controller
    {
        MainDbContext cn = new MainDbContext();
        GIOHANG dh = new GIOHANG();
        [HttpGet]
        public ActionResult Index(string SDT)
        {
            return View();

        }
        //public ActionResult Update(string tenkh, string diachi, int sdt)
        //{
        //    try
        //    {

        //        if (ModelState.IsValid)
        //        {

        //            dh.Update_DiaChi(tenkh, diachi, sdt);
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Index");
        //    }

        //
    }
}