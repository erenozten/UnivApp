using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnivApp.DAL;
using UnivApp.Methods;
using UnivApp.Models;
using UnivApp.ViewModels;

namespace UnivApp.Controllers
{
    public class InstructorController : Controller
    {
        private UnivAppContext db = new UnivAppContext();

        public ActionResult Index(int? id, int? courseID)
        {
            var viewModel = new InstructorIndexData();
            viewModel.Instructors = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.Courses.Select(c => c.Department))
                .OrderBy(i => i.LastName);

            if (id != null)
            {
                ViewBag.InstructorID = id.Value;

                viewModel.Courses = viewModel.Instructors.Where(
                    i => i.ID == id.Value).Single()
                    .Courses;
                // Biraz yukarıda, viewModel'i oluşturduk. Bu model, db'deki tüm Instructor'ları içinde bulunduruyor.
                // Şimdi gelelim sql sorgusuna...
                // Seçilmiş olan Instructor'a ait olan Course'ları seçmek istiyoruz.
                // Yani seçilmiş olan öğretmenin verdiği dersleri seçmek istiyoruz.
                // yukarıda oluşturduğumuz viewModel Instructor'ları tutuyordu. Ama ayrıca şunları da tutuyor:
                // Courses, Enrollments
                // Zaten bu viewModel'i, bu bilgileri çekmek için oluşturmuştuk. Şimdi sorguyu düşünelim:
                // viewModel.Courses = viewModel.Instructors.Where....
                // viewModel'deki Course'lar = kullanıcının seçtiği Instructor'ın verdiği Course'lar.
                // unutmayalım ki Instructor class'ı, kendi içinde Course listesi tutuyordu. Buradan istediğimize ulacağız:
                // public virtual ICollection<Course> Courses { get; set; }

                // viewModel.Courses = viewModel.Instructors.Where(  .....

                // Ama hangi Instructor'ları istiyoruz? : ID'si, kullanıcının seçmiş olduğu ID' olan Instructorları istiyoruz..
                // viewModel.Courses = viewModel.Instructors.Where(i => i.ID == id.Value) ......

                // Ama zaten bu şartı sağlayan sadece 1 tane değer olacak. O halde Single yazıp o değeri seçeceğiz:
                // viewModel.Courses = viewModel.Instructors.Where(i => i.ID == id.Value).Single() ...

                // Sonuçta bize bir Instructor dönmüş olacak (ID'si kullanıcının seçmiş olduğu Instructor'ın ID'si idi)
                // Artık ilgili Instructor'u seçtiğimize göre; bu instructor'ın Courses property'sine de erişebiliriz! :
                //viewModel.Courses = viewModel.Instructors.Where(i => i.ID == id.Value).Single().Courses;

                //Biraz karışık ama kafamıza oturttuktan sonra çok işimize yarayacak bir sorgu.
            }

            if (courseID != null)
            {
                ViewBag.CourseID = courseID.Value; // seçien Course'un arkaplan rengini değiştirmek için kullanıyoruz.

                //yukarıda Instructor için yaptığımız sorgundaki mantığı kullanarak bunu da kendimiz yazalım:
                viewModel.Enrollments = viewModel.Courses.Where(x => x.CourseID == courseID).Single().Enrollments;
            }
            return View(viewModel);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Instructor instructor = db.Instructors.Find(id);
            var instructor = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.Courses)
                .Where(i => i.ID == id)
                .Single();

            if (instructor == null)
            {
                return HttpNotFound();
            }

            ViewBag.coursesBag = instructor.Courses.ToList();
            return View(instructor);
        }

        public ActionResult Create()
        {
            var instructor = new Instructor();
            instructor.Courses = new List<Course>();
            var viewModel = InstructorMethods.PopulateAssignedCourseData(instructor);
            ViewBag.courses = viewModel;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include =
                "LastName,FirstMidName,HireDate,OfficeAssignment" )]Instructor instructor,
            string[] selectedCoursesReturnedToAction)
        {
            if (selectedCoursesReturnedToAction != null)
            {
                instructor.Courses = new List<Course>();
                foreach (var course in selectedCoursesReturnedToAction)
                {
                    var courseToAdd = db.Courses.Find(int.Parse(course));
                    instructor.Courses.Add(courseToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            InstructorMethods.PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);

            List<AssignedCourseData> listViewModel = new List<AssignedCourseData>();
            listViewModel = InstructorMethods.PopulateAssignedCourseData(instructor);

            ViewBag.Courses = listViewModel;

            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string[] selectedCoursesReturnedToAction)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var instructorToUpdate = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.Courses)
                .Where(i => i.ID == id)
                .Single();

            if (TryUpdateModel(instructorToUpdate, "", new string[] { "LastName", "FirstMidName", "HireDate", "OfficeAssignment" }))
            {
                try
                {
                    if
                        (String.IsNullOrWhiteSpace(instructorToUpdate.OfficeAssignment.Location))
                    {
                        instructorToUpdate.OfficeAssignment = null;
                    }

                    UpdateInstructorCourses(selectedCoursesReturnedToAction, instructorToUpdate);

                    db.Entry(instructorToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            InstructorMethods.PopulateAssignedCourseData(instructorToUpdate);
            return View(instructorToUpdate);
        }

        private void UpdateInstructorCourses(string[] selectedCourses, Instructor instructorToUpdate)
        {
            if (selectedCourses == null)
            {
                instructorToUpdate.Courses = new List<Course>();
                return;
            }

            var hashSetOfSelectedCoursesById = new HashSet<string>(selectedCourses);

            var hashSetOfInstructorCoursesById = new HashSet<int>(instructorToUpdate.Courses.Select(c => c.CourseID));
            //bahsi geçen instructor'un DB'deki course'lerinin ID'lerini seçip bir değişkene attık (hashetofInst....)

            foreach (var aCourseFromDb in db.Courses)
            {
                if (hashSetOfSelectedCoursesById.Contains(aCourseFromDb.CourseID.ToString()))
                //seçilen ID değerleri acaba DB'deki ID değerleriyle uyuşuyor mu. Şayet uyuşuyorsa:
                {
                    if (!hashSetOfInstructorCoursesById.Contains(aCourseFromDb.CourseID))
                    //öğretmenin ders listesinde, bu yeni gelen değer bulunmuyor mu? 
                    //öyleyse veriyi ekle. 
                    //Diğer açıklama aşağıda:

                    // bahsi geçen instructor'un db'deki course'lerinin ID'leri, db'deki herhangi bir course'nin ID sine eşit değil mi?
                    {
                        instructorToUpdate.Courses.Add(aCourseFromDb);
                        //olan şu: db deki bir ID, gelen IDlerden herhangi birine eşit değilse; bu değerin instructora eklenmesi gerekir.
                    }
                }
                else
                {
                    if (hashSetOfInstructorCoursesById.Contains(aCourseFromDb.CourseID))
                    {
                        instructorToUpdate.Courses.Remove(aCourseFromDb);
                    }
                }
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instructor instructor = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Where(i => i.ID == id)
                .Single();

            instructor.OfficeAssignment = null;
            db.Instructors.Remove(instructor);

            var department = db.Departments
                .Where(d => d.InstructorID == id)
                .SingleOrDefault();

            if (department != null)
            {
                department.InstructorID = null;
            }

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
