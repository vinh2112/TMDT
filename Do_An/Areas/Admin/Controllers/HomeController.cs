using Do_An.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            CustomerModel cus = new CustomerModel();
            ProductModel pro = new ProductModel();
            OrderModel ord = new OrderModel();
            string customer = cus.countCustomer();
            string product = pro.countProduct();
            string order = ord.countOrder();
            ViewBag.countCus = customer;
            ViewBag.countPro = product;
            ViewBag.countOrder = order;
            return View();
        }
    }
}