using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnivApp.DAL;
using UnivApp.Models;
using PagedList;
using UnivApp.DTO;
using UnivApp.Repositories.Concrete;

namespace UnivApp.Controllers
{
    public class StudentController : Controller
    {
        private UnivAppContext db = new UnivAppContext();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.FirstNameSortParm = sortOrder == "firstName_desc" ? "firstName_asc" : "firstName_desc";
            ViewBag.LastNameSortParm = sortOrder == "lastName_asc" ? "lastName_desc" : "lastName_asc";
            ViewBag.DateSortParm = sortOrder == "date_asc" ? "date_desc" : "date_asc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var students = from s in db.Students
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                UnitOfWork unitOfWork = new UnitOfWork(db);
                unitOfWork.StudentRepository.GetStudentsBySearchTerm(searchString, students);

                //students = students.Where(s =>
                //    s.LastName.ToUpper().Contains(searchString.ToUpper())
                //    ||
                //    s.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
                //Buradaki işlemi Repository'e geçirdiğimiz için yukarıyı comment'ledik. Tekrar inceleyebiliriz fikriyle comment'leri silmedik.

                students = unitOfWork.StudentRepository.GetStudentsBySearchTerm(searchString, students);
            }

            switch (sortOrder)
            {
                case "lastName_asc":
                    students = students.OrderBy(s => s.LastName);
                    break;
                case "lastName_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "firstName_asc":
                    students = students.OrderBy(s => s.FirstMidName);
                    break;
                case "firstName_desc":
                    students = students.OrderByDescending(s => s.FirstMidName);
                    break;
                case "date_asc":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.FirstMidName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student stud = db.Students.Find(id);

            UnitOfWork unitOfWork = new UnitOfWork(db);
            Student student = unitOfWork.StudentRepository.GetById(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            var asd = student.ToString();

            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWithJson(string FirstMidName, string LastName, DateTime EnrollmentDate)
        {
            var student = new Student();
            try
            {
                student.FirstMidName = FirstMidName;
                student.LastName = LastName;
                student.EnrollmentDate = EnrollmentDate;
                //db.Students.Add(student);
                //db.SaveChanges();

                UnitOfWork unitOfWork = new UnitOfWork(db);
                unitOfWork.StudentRepository.Add(student);
                unitOfWork.Complete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
          
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork unitOfWork = new UnitOfWork(new UnivAppContext());
                unitOfWork.StudentRepository.Add(student);
                unitOfWork.Complete(); //complete metodunda saveChanges yapıyoruz. Buna dikkat. Unutma yazmayı.
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UnitOfWork unitOfWork = new UnitOfWork(db);
            Student student = unitOfWork.StudentRepository.GetById(id);

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(student).State = EntityState.Modified;
                //db.SaveChanges();

                UnitOfWork unitOfWork = new UnitOfWork(db);
                unitOfWork.StudentRepository.Edit(student);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken] //hata verdi bu
        //public ActionResult Delete(int id, string[] selectedStudentsReturnedToAction)
        public ActionResult Delete(int id)
        {
            try
            {
                UnitOfWork unitOfWork = new UnitOfWork(db);
                unitOfWork.StudentRepository.Remove(id);
                unitOfWork.Complete();
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");

                return RedirectToAction("Delete", new
                {
                    id = id,
                    saveChangesError = true

                });
            }
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        public JsonResult SaveList(string ItemList)
        {
            string[] arr = ItemList.Split(',');
            int idAsInt;

            foreach(var item in arr)
            {
                idAsInt = int.Parse(item);
                var studentToRemove = db.Students.Find(idAsInt);
                db.Students.Remove(studentToRemove);
                
            }
            db.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}
