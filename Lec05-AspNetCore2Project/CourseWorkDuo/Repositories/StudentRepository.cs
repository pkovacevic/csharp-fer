using CourseWorkDuo.Entities;
using CourseWorkDuo.Entities.Db;
using CourseWorkDuo.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWorkDuo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private CourseWorkDbContext _dbContext;

        public StudentRepository(CourseWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<StudentVm>> GetStudentList()
        {
            IList<Student> studentEntities = await _dbContext.Students.ToListAsync();
            IList<StudentVm> studentVms = studentEntities.Select(x => StudentVm.FromEntity(x)).ToList();

            return studentVms;
        }

        public async Task<StudentVm> Details(int id)
        {
            Student studentEntity = await _dbContext.Students.SingleAsync(x => x.Id == id);
            StudentVm studentVm = StudentVm.FromEntity(studentEntity);

            return studentVm;
        }

        public async Task Remove(int id)
        {
            Student deleteMe = await _dbContext.Students.SingleAsync(x => x.Id == id);
            _dbContext.Students.Remove(deleteMe);
            await _dbContext.SaveChangesAsync();
        }
    }
}
