using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnivApp.DAL;
using UnivApp.Models;
using UnivApp.ViewModels;

namespace UnivApp.Methods
{
    public class InstructorMethods
    {
        private static readonly UnivAppContext db = new UnivAppContext();

        public static void PopulateListOfStudentsByOneCourse(int courseId)
        {
            //var data = from student in _context.Students
            //           group student by student.Enrollments.Where(e=>e.CourseID == courseId) into studentGroup
            //           select new studentGroup()
        }

        public static List<AssignedCourseData> PopulateAssignedCourseData(Instructor instructor)
        {
            var allCourses = db.Courses;

            var instructorCourses = new HashSet<int>(instructor.Courses.Select(c => c.CourseID)); //id'leri liste şeklinde dönderiyor. 

            var viewModel = new List<AssignedCourseData>();

            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
            return viewModel;
        }

    }
}