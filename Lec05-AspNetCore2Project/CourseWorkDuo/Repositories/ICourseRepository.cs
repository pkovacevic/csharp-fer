using System.Collections.Generic;
using System.Threading.Tasks;
using CourseWorkDuo.ViewModels;

namespace CourseWorkDuo.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseVm>> GetAllCourses();

        Task<CourseVm> GetCourseById(int id);

        Task<CourseVm> GetCourseWithStudents(int courseId);

        Task<CourseVm> GetCourseWithStudentsToAdd(int courseId);

        Task AddStudentToCourse(int courseId, int studentId);
    }
}