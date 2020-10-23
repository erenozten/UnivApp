using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnivApp.DAL;

namespace UnivApp.Controllers
{
    public class DeleteDataController : Controller
    {
        public ActionResult DeleteDepartments()
        {
            DeleteData.DeleteDepartments();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteStudents()
        {
            DeleteData.DeleteStudents();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteCourses()
        {
            DeleteData.DeleteCourses();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DeleteInstructors()
        {
            DeleteData.DeleteInstructors();
            return RedirectToAction("Index", "Home");
        }
    }
}