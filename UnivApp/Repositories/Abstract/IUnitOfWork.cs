using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivApp.Repositories.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        IStudentRepository StudentRepository { get;}
        IDepartmentRepository DepartmentRepository { get;}
        int Complete();
    }
}
