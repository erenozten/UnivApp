using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnivApp.Models ////////////////////////////////////incelendi
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }


        [Range(0, 5)]
        public int Credits { get; set; }

        public string CourseCode { get; set; } = CreateAutoCourseCode.Create();

        public string CourseCodeAndTitle
        {
            get { return CourseCode + " " + Title; }
        }

        public int DepartmentID { get; set; } //Dersin ait olduğu departmanın ID'si burada tutuluyor. Böylelikle bağlı olunan departmanın hangisi olduğunu bulabiliriz.
        public virtual Department Department { get; set; } //Bir ders, bir departmana ait olabilir.

        public virtual ICollection<Enrollment> Enrollments { get; set; } //Bir derse birçok kişi kayıt yaptırabilir.
        public virtual ICollection<Instructor> Instructors { get; set; } //Bir dersi birçok öğretmen anlatabilir.
    }
}