using MvcStock.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MvcStock.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        DbStockEntities db = new DbStockEntities();
        public ActionResult Index(int page = 1)
        {
            var products = db.Tbl_Product.ToList().ToPagedList(page, 4);

            return View(products);
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            var categories = db.Tbl_Category.ToList();

            return View(categories);
        }

        [HttpPost]
        public ActionResult NewProduct(Tbl_Product product)
        {
            db.Tbl_Product.Add(product);

            db.SaveChanges();

            var categories = db.Tbl_Category.ToList();

            return View(categories);
        }

        public ActionResult DeleteProduct(int productId)
        {

            var product = db.Tbl_Product.Find(productId);

            var products = db.Tbl_Product.ToList().ToPagedList(1, 4);

            var relatedSales = db.Tbl_Sale.Where(s => s.ProductId == productId);

            if (relatedSales.Any())
            {
                ViewBag.ErrorMessage = $"This product ('Product Name: {product.ProductName}', Product ID: '{product.ProductId}') is associated with existing sales reports. Please address those reports before proceeding.";

                return View("Index", products);
            }

            db.Tbl_Product.Remove(product);

            db.SaveChanges();

            return View("Index", products);
        }

        [HttpGet]
        public ActionResult UpdateProduct(int productId)
        {
            var categories = db.Tbl_Category.ToList();

            var product = db.Tbl_Product.Find(productId);

            ViewBag.Categories = categories;

            return View(product);
        }

        [HttpPost]
        public ActionResult UpdateProduct(int productId, Tbl_Product p1)
        {
            db.Tbl_Product.AddOrUpdate(p1);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}