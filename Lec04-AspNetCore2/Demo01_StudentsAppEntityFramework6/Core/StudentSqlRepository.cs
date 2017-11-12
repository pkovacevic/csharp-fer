using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Demo01_StudentsAppEntityFramework6.Core
{
    public class StudentSqlRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentSqlRepository(StudentDbContext context)
        {
            _context = context;
        }
        public async Task<Student> AddAsync(Student s)
        {
            _context.Students.Add(s);
            await _context.SaveChangesAsync();
            return s;
        }

        public Task<List<Student>> GetAllAsync()
        {
            return _context.Students.ToListAsync();
        }

        public Task<Student> GetAsync(string jmbag)
        {
            return _context.Students.FirstOrDefaultAsync(s => s.Jmbag == jmbag);
        }
    }
}
