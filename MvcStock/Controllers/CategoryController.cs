using MvcStock.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace MvcStock.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        DbStockEntities db = new DbStockEntities();

        public ActionResult Index(int page=1)
        {
            var categories = db.Tbl_Category.ToList().ToPagedList(page, 4);
            return View(categories);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }


        [HttpPost]
        public ActionResult NewCategory(Tbl_Category c1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.Tbl_Category.Add(c1);

            db.SaveChanges();

            return View();
        }

        public ActionResult DeleteCategory(int categoryId)
        {

            var category = db.Tbl_Category.Find(categoryId);

            db.Tbl_Category.Remove(category);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]           
        public ActionResult UpdateCategory(int categoryId)
        {
            var category = db.Tbl_Category.Find(categoryId);

            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(int categoryId, Tbl_Category c1)
        {
            db.Tbl_Category.AddOrUpdate(c1);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}