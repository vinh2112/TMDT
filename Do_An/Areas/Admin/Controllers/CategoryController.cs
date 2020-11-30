using Do_An.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var category = new CategoryModel();
            var model = category.ListAllCategory();
            ViewBag.Category = model;
            return View();
        }
    }
}