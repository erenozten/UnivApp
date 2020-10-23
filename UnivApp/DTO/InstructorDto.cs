using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnivApp.Models;

namespace UnivApp.DTO
{
    public class InstructorDto
    {
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}