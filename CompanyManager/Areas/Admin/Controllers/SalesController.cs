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
    [F7DeatAuthorize(Roles = "1")]
    public class SalesController : Controller
    {
        private CompanyContext db = new CompanyContext();

        // GET: Admin/Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Product).Include(s => s.Volume);
            return View(sales.ToList());
        }

        // GET: Admin/Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Admin/Sales/Create
        public ActionResult Create(int v)
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.ModemID = new SelectList(db.Modems, "ModemID", "ModemID");
            return View();
        }

        // POST: Admin/Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sale sale, int v)
        {
            if (ModelState.IsValid)
            {
                sale.VolumeID = v;
                db.Sales.Add(sale);
                db.SaveChanges();
                return Redirect("/Admin/Volumes/Details/" + v);
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", sale.ProductID);
            ViewBag.ModemID = new SelectList(db.Modems, "ModemID", "ModemID", sale.ModemID);
            return View(sale);
        }

        public JsonResult GetBrand(int ProductID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<BrandProduct> brands = db.BrandProducts.Where(x => x.ProductID == ProductID).ToList();
            return Json(brands, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetModem(int ProductID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Modem> modems = db.Modems.Where(x => x.ProductID == ProductID).ToList();
            return Json(modems, JsonRequestBehavior.AllowGet);
        }


        // GET: Admin/Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", sale.ProductID);
            ViewBag.VolumeID = new SelectList(db.Volumes, "VolumeID", "VolumeID", sale.VolumeID);
            return View(sale);
        }

        // POST: Admin/Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleID,ProductID,VolumeID,Quantity,Unit,Note")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", sale.ProductID);
            ViewBag.VolumeID = new SelectList(db.Volumes, "VolumeID", "VolumeID", sale.VolumeID);
            return View(sale);
        }

        // GET: Admin/Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Admin/Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
            db.SaveChanges();
            return RedirectToAction("Index");
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
