using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnivApp.DAL;
using UnivApp.Models;
using UnivApp.Repositories.Abstract;

namespace UnivApp.Repositories.Concrete
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(UnivAppContext context):base(context)
        {
        }

        public UnivAppContext UnivAppContext { get { return _db as UnivAppContext; } }

        public IEnumerable<Student> GetTopStudents(int count)
        {
            return UnivAppContext.Students.Take(count);
        }

        public IQueryable<Student> GetStudentsBySearchTerm(string searchString, IQueryable<Student> students)
        {
            students = students.Where(s =>
                    s.LastName.ToUpper().Contains(searchString.ToUpper())
                    ||
                    s.FirstMidName.ToUpper().Contains(searchString.ToUpper()));

            return students;
        }
    }
}