using Do_An.Areas.Admin.Models;
using Do_An.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult Index()
        {
            var order = new OrderModel();
            ViewBag.Order = order.ListAllOrder();
            foreach (var item in ViewBag.Order)
            {
                List<string> lstString = new List<string>();
                ViewBag.infoOrder = order.infoDonHang(item.MaDH);
                foreach (var info in ViewBag.infoOrder)
                {
                    lstString.Add(info.TenSP + "   [ -" + info.SoLuong + "- ]  ");
                }
                lstString.TrimExcess();
                ViewData[item.MaDH] = lstString;
            }
            return View();
        }
        public ActionResult Waiting()
        {
            var order = new OrderModel();
            ViewBag.Order = order.ListAllWaitingOrder();
            foreach (var item in ViewBag.Order)
            {
                List<string> lstString = new List<string>();
                ViewBag.infoOrder = order.infoDonHang(item.MaDH);
                foreach (var info in ViewBag.infoOrder)
                {
                    lstString.Add(info.TenSP + "   [ -" + info.SoLuong + "- ]  ");
                }
                lstString.TrimExcess();
                ViewData[item.MaDH] = lstString;
            }
            return View();
        }
        public ActionResult CancelOrder(string maDH)
        {
            var order = new OrderModel();
            order.cancelOrder(maDH);
            TempData["Alert-Message"] = "Hủy đơn hàng " + maDH + " thành công";
            TempData["AlertType"] = "alert-success";
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult VerifyOrder(string maDH)
        {
            int TongTien = 0;
            var order = new OrderModel();
            ViewBag.infoOrder = order.infoDonHang(maDH);
            foreach(var item in ViewBag.infoOrder)
            {
                TongTien += item.Gia;
            }
            order.verifyOrder(maDH, TongTien);
            TempData["Alert-Message"] = "Xác nhận đơn hàng " + maDH + " thành công";
            TempData["AlertType"] = "alert-success";
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult ChangeInfo(string maDH,string DiaChi)
        {
            var order = new OrderModel();
            order.chageInfo(maDH,DiaChi);
            TempData["Alert-Message"] = "Thay đổi thông tin đơn hàng " + maDH + " thành công";
            TempData["AlertType"] = "alert-success";
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}