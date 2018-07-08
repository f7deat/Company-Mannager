using CompanyManager.Common;
using CompanyManager.DAL;
using CompanyManager.Models;
using CompanyManager.Models.ViewModel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CompanyManager.Areas.Admin.Controllers
{
    [F7DeatAuthorize(Roles = "1, 2")]
    public class VolumesController : Controller
    {
        private CompanyContext db = new CompanyContext();

        public ActionResult Print(int id)
        {
            Volume volume = db.Volumes.Find(id);
            ViewBag.ListChao = db.Sales.Where(x => x.VolumeID == id).ToList();
            return View(volume);
        }

        // GET: Admin/Volumes
        public ActionResult Index()
        {
            var volumes = db.Volumes.Include(v => v.Customer).Include(v => v.User);
            return View(volumes.ToList());
        }

        // GET: Admin/Volumes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volume volume = db.Volumes.Find(id);
            var data = new VolumeIndexData();
            data.UserID = volume.UserID;
            data.VolumeName = volume.VolumeName;
            data.CompanyName = volume.Customer.CompanyName;
            data.DateCreate = volume.DateCreate;
            data.Username = volume.User.Username;
            data.VolumeID = volume.VolumeID;
            if (volume == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListChao = db.Sales.Where(x => x.VolumeID == id).ToList();
            return View(volume);
        }

        // GET: Admin/Volumes/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username");
            return View();
        }

        // POST: Admin/Volumes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VolumeID,VolumeName,DateCreate,ShipAddress,UserID,CustomerID")] Volume volume)
        {
            if (ModelState.IsValid)
            {
                var session = (UserInfo)Session[Constants.USER_SESSION];
                volume.DateCreate = DateTime.Now;
                volume.UserID = session.UserID;
                db.Volumes.Add(volume);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", volume.CustomerID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", volume.UserID);
            return View(volume);
        }

        // GET: Admin/Volumes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volume volume = db.Volumes.Find(id);
            if (volume == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", volume.CustomerID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", volume.UserID);
            return View(volume);
        }

        // POST: Admin/Volumes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VolumeID,VolumeName,DateCreate,ShipAddress,UserID,CustomerID")] Volume volume)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volume).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", volume.CustomerID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", volume.UserID);
            return View(volume);
        }
        public ActionResult DeleteSale(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteSale(int id, Sale sale, int v)
        {
            var tan = db.Sales.Find(id);
            db.Sales.Remove(tan);
            db.SaveChanges();
            return Redirect("/Admin/Volumes/Details/" + v);
        }
        // GET: Admin/Volumes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volume volume = db.Volumes.Find(id);
            if (volume == null)
            {
                return HttpNotFound();
            }
            return View(volume);
        }

        // POST: Admin/Volumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volume volume = db.Volumes.Find(id);
            db.Volumes.Remove(volume);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult ExportToExcel()
        {
            var chaogia = db.Sales.ToList();
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Cells[1, 1].Value = "STT";
            workSheet.Cells[1, 2].Value = "Tên vật tư";
            workSheet.Cells[1, 3].Value = "Mã hiệu";
            workSheet.Cells[1, 4].Value = "Hãng";
            workSheet.Cells[1, 5].Value = "ĐVT";
            workSheet.Cells[1, 6].Value = "SL";
            workSheet.Cells[1, 7].Value = "Đơn giá";
            workSheet.Cells[1, 8].Value = "Thành tiền";
            workSheet.Cells[1, 9].Value = "Ghi chú";
            //Body of table  
            int recordIndex = 2;
            foreach (var student in chaogia)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = student.Product.ProductName;
                workSheet.Cells[recordIndex, 3].Value = student.ModemID;
                workSheet.Cells[recordIndex, 4].Value = student.BrandName;
                workSheet.Cells[recordIndex, 5].Value = student.Unit;
                workSheet.Cells[recordIndex, 6].Value = student.Quantity;
                workSheet.Cells[recordIndex, 9].Value = student.Note;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            string excelName = "ChaoGia";
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=" + excelName + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
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
