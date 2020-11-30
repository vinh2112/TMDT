using Do_An.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index()
        {
            var customer = new CustomerModel();
            var model = customer.ListAllCustomer();
            ViewBag.Customer = model;
            return View();
        }
    }
}