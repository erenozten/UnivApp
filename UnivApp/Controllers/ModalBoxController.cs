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
    public class ModalBoxController : Controller
    {
        private readonly UnivAppContext db;

        public ModalBoxController()
        {
            db = new UnivAppContext();
        }
        // GET: ModalBox
        public ActionResult Index()
        {
            var anInstructor = db.Instructors.FirstOrDefault();
            var anInstructorId = anInstructor.ID;
            Instructor instructor = db.Instructors.Find(anInstructorId);
            InstructorMethods.PopulateAssignedCourseData(instructor);

            List<AssignedCourseData> listViewModel = new List<AssignedCourseData>();
            listViewModel = InstructorMethods.PopulateAssignedCourseData(instructor);
            ViewBag.Courses = listViewModel;

            var instructorList = db.Instructors.ToList();
            InstructorDto instructorDto = new InstructorDto();
            instructorDto.Instructors = instructorList;
            ViewBag.bag = instructorList;

            return View(instructorDto);
        }
    }
}