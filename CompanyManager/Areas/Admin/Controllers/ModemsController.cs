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
    public class ModemsController : Controller
    {
        private CompanyContext db = new CompanyContext();

        // GET: Admin/Modems
        public ActionResult Index()
        {
            var modems = db.Modems.Include(m => m.Product);
            return View(modems.ToList());
        }

        // GET: Admin/Modems/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modem modem = db.Modems.Find(id);
            if (modem == null)
            {
                return HttpNotFound();
            }
            return View(modem);
        }

        // GET: Admin/Modems/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: Admin/Modems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModemID,ProductID,UnitPrice")] Modem modem)
        {
            if (ModelState.IsValid)
            {
                db.Modems.Add(modem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", modem.ProductID);
            return View(modem);
        }

        // GET: Admin/Modems/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modem modem = db.Modems.Find(id);
            if (modem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", modem.ProductID);
            return View(modem);
        }

        // POST: Admin/Modems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModemID,ProductID,UnitPrice")] Modem modem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", modem.ProductID);
            return View(modem);
        }

        // GET: Admin/Modems/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modem modem = db.Modems.Find(id);
            if (modem == null)
            {
                return HttpNotFound();
            }
            return View(modem);
        }

        // POST: Admin/Modems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Modem modem = db.Modems.Find(id);
            db.Modems.Remove(modem);
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
