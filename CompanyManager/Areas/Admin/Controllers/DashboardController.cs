using CompanyManager.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyManager.DAL;

namespace CompanyManager.Areas.Admin.Controllers
{
    [F7DeatAuthorize(Roles = "1, 2")]
    public class DashboardController : Controller
    {
        private CompanyContext db = new CompanyContext();
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            ViewBag.ProductCount = db.Products.Count();
            ViewBag.VolumeCount = db.Volumes.Count();
            ViewBag.BrandCount = db.Brands.Count();
            ViewBag.UserCount = db.Users.Count();
            return View();
        }
    }
}