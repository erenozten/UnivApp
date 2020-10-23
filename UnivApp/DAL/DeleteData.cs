using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnivApp.DAL
{
    public class DeleteData
    {
        static UnivAppContext context = new UnivAppContext();

        public static void DeleteDepartments()
        {
            var departmentsListCount = context.Departments.Count();

            if (departmentsListCount == 0)
            {
                return;
            }
            else
            {
                var departmentsList = context.Departments.ToList();
                foreach (var item in departmentsList)
                {
                    context.Departments.Remove(item);
                    context.SaveChanges();
                }
            }
        }

        public static void DeleteStudents()
        {
            var studentsListCount = context.Students.Count();

            if (studentsListCount == 0)
            {
                return;
            }
            else
            {
                var studentsList = context.Students.ToList();
                foreach (var item in studentsList)
                {
                    context.Students.Remove(item);
                    context.SaveChanges();
                }
            }
        }

        public static void DeleteCourses()
        {
            var coursesListCount = context.Courses.Count();

            if (coursesListCount == 0)
            {
                return;
            }
            else
            {
                var coursesList = context.Courses.ToList();
                foreach (var item in coursesList)
                {
                    context.Courses.Remove(item);
                    context.SaveChanges();
                }
            }
        }

        public static void DeleteInstructors()
        {
            var instructorsListCount = context.Instructors.Count();

            if (instructorsListCount == 0)
            {
                return;
            }
            else
            {
                var instructorsList = context.Courses.ToList();
                foreach (var item in instructorsList)
                {
                    context.Courses.Remove(item);
                    context.SaveChanges();
                }
            }
        }
    }
}