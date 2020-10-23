using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UnivApp.Models
{
    public class Student : Person
    {
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Enrollment Date")]
        private DateTime _enrollmentDate = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate
        {
            get
            {
                return _enrollmentDate;
            }
            set
            { _enrollmentDate = value; }
        }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}