using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompanyManager.Common;
using CompanyManager.DAL;
using CompanyManager.Models;

namespace CompanyManager.Areas.Admin.Controllers
{
    [F7DeatAuthorize(Roles = "1, 2")]
    public class BrandsController : Controller
    {
        private CompanyContext db = new CompanyContext();

        // GET: Admin/Brands
        public ActionResult Index()
        {
            return View(db.Brands.ToList());
        }

        // GET: Admin/Brands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            var bp = db.BrandProducts.Where(x => x.BrandID == id).ToList();
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(bp);
        }

        // GET: Admin/Brands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrandID,BrandName")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brand);
        }

        // GET: Admin/Brands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Admin/Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrandID,BrandName")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        // GET: Admin/Brands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }
        public ActionResult AddProduct(int id)
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(int id, BrandProduct brandProduct)
        {
            if(ModelState.IsValid)
            {
                brandProduct.BrandID = id;
                brandProduct.BrandName = db.Brands.Where(x => x.BrandID == id).Select(x => x.BrandName).FirstOrDefault();
                db.BrandProducts.Add(brandProduct);
                db.SaveChanges();
                return RedirectToAction("Details/" + id);
            }
            return View();
        }
        public ActionResult DeleteProduct(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id, BrandProduct brandProduct)
        {
            var tan = db.BrandProducts.Find(id);
            db.BrandProducts.Remove(tan);
            db.SaveChanges();
            return Redirect("/Admin/Brands");
        }

        // POST: Admin/Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetProducts(string q)
        {
            var query = db.Products.Where(x=>x.ProductName.Contains(q)).Select(x => new {
                x.ProductID,
                x.ProductName
            }).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
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
