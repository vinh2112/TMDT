﻿using Do_An.Areas.Admin.Models;
using Do_An.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            Session["URL"] = null;

            var product = new ProductModel();
            var brand = new BrandModel();
            var category = new CategoryModel();
            ViewBag.Product = product.ListAll();
            ViewBag.Brand = brand.ListAllBrand();
            ViewBag.Category = category.ListAllCategory();
            return View();
        }

        public ActionResult SanPhamTheoThuongHieu(string maTH)
        {
            Session["URL"] = null;

            ViewBag.maTh = maTH;
            var product = new ProductModel();
            var brand = new BrandModel();
            var category = new CategoryModel();
            var model = product.ListAllbyBrand(maTH);
            ViewBag.Brand = brand.ListAllBrand();
            ViewBag.Category = category.ListAllCategory();
            return View(model);
        }
        public ActionResult SanPhamTheoDanhMuc(string maDM)
        {
            Session["URL"] = null;

            ViewBag.maDM = maDM;
            var product = new ProductModel();
            var brand = new BrandModel();
            var category = new CategoryModel();
            var model = product.ListAllbyCategory(maDM);
            ViewBag.Brand = brand.ListAllBrand();
            ViewBag.Category = category.ListAllCategory();
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(string maSP, string type = null)
        {
            if(Session["URL"] == null)
            {
                Session["URL"] = HttpContext.Request.UrlReferrer.AbsoluteUri.ToString();
                ViewBag.URL = Session["URL"];
            }
            else
            {
                ViewBag.URL = Session["URL"];
            }
            if (type == "success")
            {
                TempData["Alert-Message"] = "Chỉnh sửa sản phẩm thành công";
                TempData["AlertType"] = "alert-success";
            }
            else
            {
                if (type == "fail")
                {
                    TempData["Alert-Message"] = "Chỉnh sửa sản phẩm thất bại";
                    TempData["AlertType"] = "alert-danger";
                }
            }
            var product = new ProductModel();
            var brand = new BrandModel();
            var category = new CategoryModel();
            ViewBag.Product = product.infoProduct(maSP);
            ViewBag.Brand = brand.ListAllBrand();
            ViewBag.Category = category.ListAllCategory();
            return View();
        }

        [HttpPost]
        public ActionResult Edit(SANPHAM product, HttpPostedFileBase file, string cates)
        {
            if (ModelState.IsValid)
            {
                product.MaDM = cates;
                if (file != null && file.ContentLength > 0)
                {
                    string filename = System.IO.Path.GetFileName(file.FileName);
                    string urlfile = Server.MapPath("~/Images/" + filename);
                    file.SaveAs(urlfile);

                    product.HinhAnh = "/Images/" + filename;
                }

                var pro = new ProductModel();
                bool res = pro.updateProduct(product);
                if (res)
                {
                    return RedirectToAction("Edit", "Product", new { maSP = product.MaSP, type = "success" });
                }
            }
            return View(product);
        }
        [HttpGet]
        public ActionResult Delete(string maSP)
        {
            var pro = new ProductModel();
            pro.deleteProduct(maSP);
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Insert(string type = null)
        {
            //Lưu URL
            if (Session["URL"] == null)
            {
                Session["URL"] = HttpContext.Request.UrlReferrer.AbsoluteUri.ToString();
                ViewBag.URL = Session["URL"];
            }
            else
            {
                ViewBag.URL = Session["URL"];
            }

            if (type == "success")
            {
                TempData["Alert-Message"] = "Thêm sản phẩm thành công";
                TempData["AlertType"] = "alert-success";
            }
            else
            {
                if (type == "fail")
                {
                    TempData["Alert-Message"] = "Thêm sản phẩm thất bại";
                    TempData["AlertType"] = "alert-danger";
                }
            }
            var brand = new BrandModel();
            var category = new CategoryModel();
            ViewBag.Brand = brand.ListAllBrand();
            ViewBag.Category = category.ListAllCategory();
            return View();
        }
        [HttpPost]
        public ActionResult Insert(SANPHAM product, string brand, string category, HttpPostedFileBase file)
        {
            product.MaTH = brand;
            product.MaDM = category;

            if (file != null && file.ContentLength > 0)
            {
                string filename = System.IO.Path.GetFileName(file.FileName);
                string urlfile = Server.MapPath("~/Images/" + filename);
                file.SaveAs(urlfile);

                product.HinhAnh = "/Images/" + filename;
            }

            var pro = new ProductModel();
            bool res = pro.insertProduct(product);
            if (res)
            {
                return RedirectToAction("Insert", "Product", new { type = "success" });
            }
            else
            {
                return RedirectToAction("Insert", new { type = "fail" });
            }
        }

        public ActionResult Stored()
        {
            Session["URL"] = null;

            var product = new ProductModel();
            var brand = new BrandModel();
            var category = new CategoryModel();
            var model = product.ListAlllowQuantity();
            ViewBag.Brand = brand.ListAllBrand();
            ViewBag.Category = category.ListAllCategory();
            return View(model);
        }
    }
}