using HomeWork6.DataAccess;
using HomeWork6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork6.Controllers
{
    public class HomeController : Controller
    {
        private ShopContext db = new ShopContext();
        
        public ActionResult Index()
        {
            var posts = db.Products.ToList();
            ViewData["Products"] = posts;

            return View();
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, string description, string price)
        {
            db.Products.Add(new Product { Name = name, Description = description, Price = price });
            db.SaveChanges();
            var script = "window.location ='" + Url.Action("Index", "Home") + "' ;";
            return JavaScript(script);
        }

        public ActionResult Delete(Guid id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Details(Guid id)
        {
            Product product = db.Products.Find(id);
            ViewData["Product"] = product;

            return View();
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