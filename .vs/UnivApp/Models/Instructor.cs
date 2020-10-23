using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnivApp.Models;

namespace UnivApp.Models ///////////////////////////////ok
{
    public class Instructor: Person
    {
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate{ get; set; } = DateTime.Now;

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Belirtilmedi")]
        public virtual ICollection<Course> Courses { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Belirtilmedi")]
        public virtual OfficeAssignment OfficeAssignment { get; set; }

        //AŞAĞIDA DATABASE İŞLEMLERİ ANLATILIYOR. ESKİ KOD:

        //public int ID { get; set; }

        //[Column("FirstName"), Display(Name = "First Name"), StringLength(50,
        //     MinimumLength = 1)]
        //public string FirstMidName { get; set; }

        //[Display(Name = "Last Name"), StringLength(50, MinimumLength = 1)]
        //public string LastName { get; set; }

        //[DataType(DataType.Date), Display(Name = "Hire Date")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime HireDate { get; set; }

        //[Display(Name = "Full Name")]
        //public string FullName
        //{
        //    get { return FirstMidName + " " + LastName; }
        //}

        ////public virtual ICollection<Course> Courses { get; set; } //Bir instructor birçok ders anlatabilir.

        ////Instructor Class'ı, nullable bir OfficeAssignment navigasyon property'sine sahip. Çünkü Instructor'a ofis ataması yapılmış da olabilir, yapılmamış da olabilir.
        //// Fakat OfficeAssignment Class'ı (evet Class, property değil Class'tan bahsediyoruz), nullable OLMAYAN bir Instructor'a sahip. Çünkü ortada bir OfficeAssignment kaydı varsa (instance'ı oluşturulmuşsa), o halde bu kayıt bir Instructor'a aittir. O halde nullable olmayan bir Instructor'a ihtiyacımız var. Bi de OfficeAssignment Class'ına gidip bunu belirttik. No 523'te.
        //public virtual OfficeAssignment OfficeAssignment { get; set; }


        ////her seferinde controller kısmında instructor.Courses = new List<Course>(); yazacağımıza aşağıdaki gibi get set'i düzenledik:
        //private ICollection<Course> _courses;
        //public virtual ICollection<Course> Courses
        //{
        //    get { return _courses ?? (_courses = new List<Course>());}

        //    set
        //    {
        //        _courses = value;
        //    }
        //} //Bir instructor birçok ders anlatabilir.
    }
}

