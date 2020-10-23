using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnivApp.DAL;
using UnivApp.Models;
using UnivApp.Repositories.Abstract;

namespace UnivApp.Repositories.Concrete
{
    public class DepartmentRepository: Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(UnivAppContext db): base(db)
        {
        }

        public void GetAllDepartmentsByBlaBla() {
        }

        public UnivAppContext UnivAppContext { get { return _db as UnivAppContext; } }
    }
}