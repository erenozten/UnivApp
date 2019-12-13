using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnivApp.Models;

namespace UnivApp.Repositories.Abstract
{
    public interface IStudentRepository: IRepository<Student>
    {
        // generic kullanmadık yukarıda görüldüğü gibi. Çünkü zaten Student class'ından gelecek veri... Çünkü bu Interface zaten sadece student'larla ilgili işlem yapacak adından da anlaşılacağı üzere...

        IEnumerable<Student> GetTopStudents(int count);
        IQueryable<Student> GetStudentsBySearchTerm(string searchString, IQueryable<Student> students);


    }
}
