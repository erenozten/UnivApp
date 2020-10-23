using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnivApp.DAL;
using UnivApp.Models;
using UnivApp.ViewModels;

namespace UnivApp.Controllers
{
    public class HomeController : Controller
    {
        private UnivAppContext db = new UnivAppContext();
        public ActionResult Index()
        {
            var courseList = db.Courses.ToList();
            HashSet<Course> hashSet2 = new HashSet<Course>();

            foreach (var item in courseList.ToList())
            {
                hashSet2.Add(item);
            }
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            return View();
        }

        public ActionResult About()
        {
            IQueryable<EnrollmentDateGroup> data =
                from student in db.Students
                group student by student.EnrollmentDate
                into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}