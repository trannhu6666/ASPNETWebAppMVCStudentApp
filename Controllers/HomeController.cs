using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETWebAppMVCStudentApp;
namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
   
        public ActionResult Departments()
        {
            return View();
        }

        public ActionResult Instructors()
        {
            return View();
        }

        public ActionResult Courses()
        {
            return View();
        }

        public ActionResult Students()
        {
            return View();
        }
        public ActionResult Enrollments()
        {
            return View();
        }
    }
}