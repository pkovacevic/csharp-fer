using CourseWorkDuo.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseWorkDuo.Repositories
{
    public interface IStudentRepository
    {
        Task<IList<StudentVm>> GetStudentList();

        Task<StudentVm> Details(int id);
    }
}
