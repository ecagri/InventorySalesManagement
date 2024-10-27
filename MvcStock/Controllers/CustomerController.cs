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
    public class CustomerController : Controller
    {
        // GET: Customer

        DbStockEntities db = new DbStockEntities();
        public ActionResult Index(string key, int page = 1)
        {
            var customers = from d in db.Tbl_Customer select d;

            if (!string.IsNullOrEmpty(key))
            {
                customers = customers.Where(c => c.CustomerName.Contains(key) || c.CustomerSurname.Contains(key));
            }

            return View(customers.ToList().ToPagedList(page, 4));
        }

        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(Tbl_Customer c1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
            db.Tbl_Customer.Add(c1);

            db.SaveChanges();

            return View();
        }

        public ActionResult DeleteCustomer(int customerId)
        {
            var customer = db.Tbl_Customer.Find(customerId);

            db.Tbl_Customer.Remove(customer);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCustomer(int customerId)
        {
            var customer = db.Tbl_Customer.Find(customerId);

            return View(customer);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(int customerId, Tbl_Customer c1)
        {
            db.Tbl_Customer.AddOrUpdate(c1);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}