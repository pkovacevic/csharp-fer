using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo01_StudentsAppEntityFramework6.Core
{
    public interface IStudentRepository
    {
        Task<Student> AddAsync(Student s);
        Task<List<Student>> GetAllAsync();
        Task<Student> GetAsync(string jmbag);
    }
}