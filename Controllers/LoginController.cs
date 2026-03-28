using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASPNETWebAppMVCStudentApp;

namespace ASPNETWebAppMVCStudentApp.Controllers
{
    public class LoginController : Controller
    {
        private SchoolDBEntities db = new SchoolDBEntities();

        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Username, string Password)
        {
            var user = db.tblUsers.FirstOrDefault(u => u.Username == Username
                                                    && u.Password == Password
                                                    && u.IsActive == true);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Tên đăng nhập, mật khẩu không đúng hoặc tài khoản bị khóa!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
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