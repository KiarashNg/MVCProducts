using Product.DAL;
using Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDBContext db;

        public ProductController()
        {
            db = new ProductDBContext();
        }
        public ActionResult Index()
        {
            var list = new List<product>();
            list = db.Products.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(product entity)
        {
            if(ModelState.IsValid)
            {

            }

            if(db.Products.Any(x => x.Id == entity.Id))
            {
                ViewBag.Message = "This Product Already Exists!";
                return View(entity);
            }

            if(entity.BrandName == null)
            {
                ViewBag.Message = "Please Enter the Brand Name!";
                return View(entity);
            }

            if (entity.ModelNo == null)
            {
                ViewBag.Message = "Please Enter the Model Number!";
                return View(entity);
            }

            db.Products.Add(entity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var entity = db.Products.Find(Id);

            if(entity == null)
            {
                ViewBag.Message = "Couldn't find the Product!";
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(product entity)
        {
          //  if(db.Products.Any(x => x.Id == entity.Id))
         //   {
           //     ViewBag.Message = "The Product Code is Already Entered";
             //   return View(entity);
          //  }
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int code)
        {
            var entity = db.Products.FirstOrDefault(x => x.Id == code);

            if(entity == null)
            {
                ViewBag.Message = "Not Found!";
                return RedirectToAction("Index");
            }

            db.Products.Remove(entity);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}