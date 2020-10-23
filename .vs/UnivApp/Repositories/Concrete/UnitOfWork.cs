using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnivApp.DAL;
using UnivApp.Repositories.Abstract;

namespace UnivApp.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private UnivAppContext _db;

        public UnitOfWork(UnivAppContext db)
        {
            _db = db;
            StudentRepository = new StudentRepository(_db);
            DepartmentRepository = new DepartmentRepository(_db);
        }
        public IStudentRepository StudentRepository { get; private set;}

        public IDepartmentRepository DepartmentRepository { get; private set; }

        public int Complete()
        {
           return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}