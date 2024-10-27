using MvcStock.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStock.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        DbStockEntities db = new DbStockEntities();

        private void SetViewBags()
        {
            ViewBag.Products = db.Tbl_Product.ToList();
            ViewBag.Customers = db.Tbl_Customer.ToList();
        }

        public ActionResult Index(int page = 1)
        {
            SetViewBags();

            var sales = db.Tbl_Sale.ToList().ToPagedList(page, 4);

            return View(sales);
        }

        [HttpGet]
        public ActionResult NewSale()
        {
            SetViewBags();

            return View();
        }

        [HttpPost]
        public ActionResult NewSale(Tbl_Sale sale)
        {
            SetViewBags();

            var product = db.Tbl_Product.Find(sale.ProductId);

            product.ProductStock -= sale.SaleQuantity;

            db.Tbl_Sale.Add(sale);

            db.Tbl_Product.AddOrUpdate(product);

            db.SaveChanges();

            return View("Index", db.Tbl_Sale.ToList().ToPagedList(1, 4));
        }
    }
}