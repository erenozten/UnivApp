using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnivApp.Models;

namespace UnivApp.Models ///////////////////////////incelendi
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        private decimal _budget = 0;

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }

        private DateTime _startDate = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public int? InstructorID { get; set; } //Yönetici hem olabilir, hem olmayabilir. O halde nullable. (bir departmanın bir Admini olur)

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Belirtilmedi")]
        public virtual Instructor Administrator { get; set; } //bir departmanın bir Admini olur. O halde IColection kullanmamalıyız. // The navigation property is named Administrator but holds an Instructor entity.
        public virtual ICollection<Course> Courses { get; set; } //Bir departmanda birçok ders olabilir. 
    }
}

