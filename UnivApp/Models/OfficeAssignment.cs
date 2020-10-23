using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UnivApp.Models
{
    public class OfficeAssignment 
    {
        //OfficeAssignment ile Instructor arasında 1'e 0 veya 1'e 1 ilişkiye sahip olmalıdır.
        //Bir ofis ataması; ancak bir Öğretmen var olduğu sürece var olur. O yüzden OfficeAssignment Class'ımız nullable olmayan bir Instructor'a sahip.

        //Görüldüğü gibi InstructorID nullable değil. Çünkü o bir primary key. Ve aynı zamanda foreign key.
        //523
        //Ayrıca: You could put a [Required] attribute on the Instructor navigation property to specify that there must be a related instructor, but you don't have to do that because the InstructorID foreign key (which is also the key to this table) is non-nullable.
        [Key] //primary key olduğunu belli etmek için yazdık. Çünkü implicit olarak bunun bir primary key olduğunu anlayamazdı Csharp.
        [ForeignKey("Instructor")]
        public int InstructorID { get; set; } //hem foreign key, hem de primary key.

        [StringLength(50)]
        [Display(Name = "Office Location")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Belirtilmedi")]
        public string Location { get; set; }

        //buraya required yazabilirmişiz. ama gerek yokmuş (biz yazıp bi deneyelim bakalım). Neden çünkü Foreign Key imiz (InstructorID) nullable değil. (ayrıca burada foreign key'imiz olan InstructorId aynı zamanda Primary key). 
        // Mantık: ofis ataması ancak şu şekilde gerçekleşmez mi zaten? : Hem Primary key'imiz olan InstructorID miz kesinlikle bulunmalı (çünkü bir atama yapıyorsak; bir öğretmene ihtiyacımız var).
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Belirtilmedi")]
        public virtual Instructor Instructor { get; set; }
    }
}