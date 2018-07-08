using CompanyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyManager.DAL;
using CompanyManager.Common;

namespace CompanyManager.Controllers
{
    public class HomeController : Controller
    {
        private CompanyContext db = new CompanyContext();
        public ActionResult Index()
        {
            var session = (UserInfo)Session[Constants.USER_SESSION];
            if(session!= null)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            if(ModelState.IsValid)
            {
                var res = db.Users.Count(x => x.Username == user.Username && x.Password == user.Password);
                if (res > 0)
                {
                    var getUser = db.Users.Single(x => x.Username == user.Username && x.Password == user.Password);
                    var userSession = new UserInfo();
                    userSession.UserID = getUser.UserID;
                    userSession.Username = getUser.Username;
                    userSession.Roles = getUser.RoleID;
                    Session.Add(Constants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else
                {
                    ViewBag.Notify = "Tài khoản hoặc mật khẩu không chính xác!";
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return RedirectToAction("Index");
        }
    }
}