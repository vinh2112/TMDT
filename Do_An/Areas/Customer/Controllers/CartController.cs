using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An.Areas.Customer.Models;
using Do_An.Frameworks;

namespace Do_An.Areas.Customer.Controllers
{
    public class CartController : Controller
    {
        private MainDbContext db = new MainDbContext();
        CartModel gh = new CartModel();

        // GET: GIOHANGs
        public ActionResult Index(string sdt = "123")
        {
            var sanpham = (from s in db.GIOHANGs where s.SDT == sdt select s).ToList();
            ViewBag.GioHang = sanpham;
            return View();
        }
        public ActionResult ThemGioHang(string sdt, string MaSP, int soluong)
        {
            gh.ThemGioHang(sdt,MaSP,soluong);

            return RedirectToAction("Index","Home");
        }
        public ActionResult XoaKhoiGio(string sdt, string MaSP)
        {
            gh.XoaSanPham(sdt, MaSP);
            return RedirectToAction("Index");
        }
        public ActionResult QuayVe()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ChonTatCa()
        {
            bool check = true;
            ViewBag.CheckAll = check;
            return RedirectToAction("Index", new { sdt = 123, check = true });
        }
        [HttpPost]
        public ActionResult SuaSoLuong(int STT, int SoLuong)
        {
            gh.SuaSoLuong(STT, SoLuong);
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}