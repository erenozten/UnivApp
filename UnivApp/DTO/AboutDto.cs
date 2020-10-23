using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnivApp.Models;
using UnivApp.ViewModels;

namespace UnivApp.DTO
{
    public class AboutDto
    {
        public List<EnrollmentDateGroup> GroupStudents { get; set; } = null;
        public List<Instructor> Instructors { get; set; }
    }
}