using CourseWorkDuo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWorkDuo.Repositories
{
    public interface IStudentRepository
    {
        Task<IList<StudentVm>> GetStudentList();

        Task<StudentVm> Details(int id);
    }
}
