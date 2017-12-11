using CourseWorkDuo.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseWorkDuo.Repositories
{
    public interface IStudentRepository
    {
        Task<IList<StudentVm>> GetStudentList();

        Task<StudentVm> GetSudentById(int id);

        Task Remove(int id);
        Task Edit(StudentVm vm);
    }
}
