using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnivApp.Models;
using UnivApp.DAL;
using UnivApp.Methods;
using UnivApp.ViewModels;

namespace UnivApp.Controllers
{
    public class JsonController : Controller
    {
        private UnivAppContext db = new UnivAppContext();

        public static string FirstCharToUpper(string gelenString)
        {
            var gelenAssignedString = gelenString;
            gelenAssignedString = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(gelenAssignedString.ToLower());
            return gelenAssignedString;
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
                    //Diger açıklama aşağıda:

                    // bahsi geçen instructor'un db'deki course'lerinin ID'leri, db'deki herhangi bir course'nin ID sine eşit değil mi?
                    {
                        instructorToUpdate.Courses.Add(aCourseFromDb);

                        //olay şu: db deki bir ID, gelen IDlerden herhangi birine eşit değilse; bu değerin instructora eklenmesi gerekir.
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


        [HttpPost]
        public JsonResult SaveRadioButtonCoursesJson(string radioButtonCoursesIdListInActionResult, int instructorIdInActionResult)
        {
            var instrutorWillUpdated = db.Instructors.Find(instructorIdInActionResult);

            string[] arr = radioButtonCoursesIdListInActionResult.Split(',');
            int idAsInt;

            foreach (var item in arr)
            {
            }
            UpdateInstructorCourses(arr, instrutorWillUpdated);

            db.Entry(instrutorWillUpdated).State = EntityState.Modified;
            db.SaveChanges();

            try
            {
                //Instructor instructor = db.Instructors.Find(radioButtonCoursesIdListInActionResult);

                //List<AssignedCourseData> listViewModel = new List<AssignedCourseData>();
                //listViewModel = InstructorMethods.PopulateAssignedCourseData(instructor);
                //ViewBag.Courses = listViewModel;

                //var assignedCoursesIdList = new HashSet<int>();

                //foreach (var item in listViewModel)
                //{
                //    if (item.Assigned)
                //    {
                //        assignedCoursesIdList.Add(item.CourseID);
                //    }
                //}

                //if (instructor == null)
                //{
                //    return HttpNotFound();
                //}
                //ViewBag.ID = new SelectList(db.OfficeAssignments, "InstructorID", "Location", instructor.ID);

                return Json(new
                {
                    //newInstructorIdReturnedByJson = instructor.ID,
                    //LastNameReturnedByJson = studentAvatar.LastName,
                    //assignedCoursesIdListReturnedByJson = assignedCoursesIdList
                },
                    JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, IsItInteger = true });
            }
            return Json(new { IsItInteger = false, success = false, ErrorMessage = "My error message" });
        }

        [HttpPost]
        public JsonResult GetInstructorIdAndPostCoursesJson(int? instructorIdInActionResult)
        {
            try
            {
                Instructor instructor = db.Instructors.Find(instructorIdInActionResult);

                List<AssignedCourseData> listViewModel = new List<AssignedCourseData>();
                listViewModel = InstructorMethods.PopulateAssignedCourseData(instructor);
                ViewBag.Courses = listViewModel;

                var assignedCoursesIdList = new HashSet<int>();

                foreach (var item in listViewModel)
                {
                    if (item.Assigned)
                    {
                        assignedCoursesIdList.Add(item.CourseID);
                    }
                }

                //if (instructor == null)
                //{
                //    return HttpNotFound();
                //}
                //ViewBag.ID = new SelectList(db.OfficeAssignments, "InstructorID", "Location", instructor.ID);

                return Json(new
                {
                    //newInstructorIdReturnedByJson = instructor.ID,
                    //LastNameReturnedByJson = studentAvatar.LastName,
                    assignedCoursesIdListReturnedByJson = assignedCoursesIdList
                },
                    JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, IsItInteger = true });
            }

            return Json(new { IsItInteger = false, success = false, ErrorMessage = "My error message" });
        }

        [HttpPost]
        public JsonResult GetInstructorDataJson(string instructorNameInActionResult, string instructorLastNameInActionResult)
        {
            if (String.IsNullOrWhiteSpace(instructorNameInActionResult) || String.IsNullOrWhiteSpace(instructorLastNameInActionResult))
            {
                //throw new Exception("nabıyon aq");
                return Json(new { message = "İsim veya soyisim boş bırakılamaz.", isNameOrLastNameNull = true });
            }
            try
            {
                
                Instructor instructor = new Instructor();
                var capitalizedInstructorName = FirstCharToUpper(instructorNameInActionResult);
                var capitalizedInstructorLastName = FirstCharToUpper(instructorLastNameInActionResult);
                instructor.FirstMidName = capitalizedInstructorName;
                instructor.LastName = capitalizedInstructorLastName;
                db.Instructors.Add(instructor);
                db.SaveChanges();

                var fullname = instructor.FirstMidName +" " + instructor.LastName;

                return Json(new
                {
                    message = "Success!",
                    newInstructorIdReturnedByJson = instructor.ID,
                    isNewInstructorCreated = true,
                    instructorHere = instructor
                },
                    JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, IsItInteger = true });
            }
        }


        [HttpGet]
        public JsonResult getStudentJson(string id)
        {
            Student studentAvatar = new Student();
            int idInt;
            bool successStringToInt = Int32.TryParse(id, out idInt);
            if (successStringToInt)
            {
                try
                {
                    Student studentReal = db.Students.FirstOrDefault(s => s.ID == idInt);
                    studentAvatar.FirstMidName = studentReal.FirstMidName;
                    studentAvatar.LastName = studentReal.LastName;
                    studentAvatar.ID = studentReal.ID;
                    return Json(new
                    {
                        success = true,
                        IsItInteger = true,
                        FirstMidNameReturnedByJson = studentAvatar.FirstMidName,
                        LastNameReturnedByJson = studentAvatar.LastName,
                        IdReturnedByJson = studentAvatar.ID
                    },
            JsonRequestBehavior.AllowGet);
                }
                catch
                {
                    return Json(new
                    {
                        success = false,
                        IsItInteger = true
                    },
                        JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                IsItInteger = false,
                success = false, ErrorMessage = "My error message"
            },
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetInstructors(string id)
        {
            var instructorList = db.Instructors.ToList();
            return Json(new { instructorList, ErrorMessage = "My error message" });
        }
    }
}

