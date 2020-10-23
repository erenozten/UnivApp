using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnivApp.DAL;
using UnivApp.DTO;
using UnivApp.Methods;
using UnivApp.Models;
using UnivApp.ViewModels;

namespace UnivApp.Controllers
{
    public class TestsController : Controller
    {
        private UnivAppContext db = new UnivAppContext();
        public ActionResult Index()
        {
            //var anInstructor = db.Instructors.FirstOrDefault();
            //var anInstructorId = anInstructor.ID;
            //Instructor instructor = db.Instructors.Find(anInstructorId);
            //InstructorMethods.PopulateAssignedCourseData(instructor);

            //List<AssignedCourseData> listViewModel = new List<AssignedCourseData>();
            //listViewModel = InstructorMethods.PopulateAssignedCourseData(instructor);
            //ViewBag.Courses = listViewModel;

            //var instructorList = db.Instructors.ToList();

            //InstructorDto instructorDto = new InstructorDto();

            //instructorDto.Instructors = instructorList;
            //ViewBag.bag = instructorList;


            IQueryable<EnrollmentDateGroup> data =
                from student in db.Students
                group student by student.EnrollmentDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };
            return View(data.ToList());
        }

        //public ActionResult Index()
        //{
        //    IQueryable<EnrollmentDateGroup> data = from student in db.Students
        //        group student by student.EnrollmentDate into dateGroup
        //        select new EnrollmentDateGroup()
        //        {
        //            EnrollmentDate = dateGroup.Key,
        //            StudentCount = dateGroup.Count()
        //        };

        //    var aboutDto = new AboutDto();
        //    aboutDto.Instructors = db.Instructors.ToList();
        //    aboutDto.GroupStudents = data;

        //    return View(aboutDto);
        //}
    }
}