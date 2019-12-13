using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UnivApp.Models;

namespace UnivApp.Models///////////////////////////incelendi
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Belirtilmedi")]
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; } //  Bir kayıt --> bir derse aittir.
        public virtual Student Student { get; set; } //Bir kayıt --> bir öğrenciye aittir.
    }
}