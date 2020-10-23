using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using UnivApp.DAL;
using UnivApp.Models;

namespace UnivApp.Controllers
{
    public class EnrollmentController : Controller
    {
        private UnivAppContext db = new UnivAppContext();

        public ActionResult Index(int? page)
        {
            var enrollments = db.Enrollments.Include(e => e.Course).Include(e => e.Student);

            var enrollmentsSelected = from s in db.Enrollments
                select s;
            enrollmentsSelected = enrollmentsSelected.OrderByDescending(c => c.EnrollmentID);

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(enrollmentsSelected.ToPagedList(pageNumber, pageSize));
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = await db.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title");
            ViewBag.StudentID = new SelectList(db.People, "ID", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EnrollmentID,CourseID,StudentID," +
                                                               "Grade" +
                                                               "" +
                                                               "")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                {
                    var newEnrollmentCourseId = enrollment.CourseID;
                    var newEnrollmentStudentId = enrollment.StudentID;

                    var course = db.Courses.Find(enrollment.CourseID);
                    var student = db.Students.Find(enrollment.StudentID);

                    //db.Enrollments.Where(e => e.CourseID == newEnrollmentCourseId);
                    //db.Enrollments.Where(e => e.StudentID == newEnrollmentStudentId);

                    foreach (var item in db.Enrollments)
                    {
                        if (item.StudentID == newEnrollmentStudentId && item.CourseID == newEnrollmentCourseId)
                        {
                            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title");
                            ViewBag.StudentID = new SelectList(db.People, "ID", "FullName");
                            string errorMessage = "Error. " + student.FullName + " has already an enrollment for " + course.Title;
                            ViewBag.errorForCreateEnrollment = errorMessage;
                            return View(enrollment);
                        }
                    }
                }
                db.Enrollments.Add(enrollment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.People, "ID", "LastName", enrollment.StudentID);
            return View(enrollment);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = await db.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.People, "ID", "LastName", enrollment.StudentID);
            return View(enrollment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EnrollmentID,CourseID,StudentID,Grade")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.People, "ID", "LastName", enrollment.StudentID);
            return View(enrollment);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = await db.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Enrollment enrollment = await db.Enrollments.FindAsync(id);
            db.Enrollments.Remove(enrollment);
            await db.SaveChangesAsync();
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
