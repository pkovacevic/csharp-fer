using CourseWorkDuo.Entities;
using CourseWorkDuo.Entities.Db;
using CourseWorkDuo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWorkDuo.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseWorkDbContext _dbContext;

        public CourseRepository(CourseWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddStudentToCourse(int courseId, int studentId)
        {
            Course courseEntity = await _dbContext.Courses.SingleAsync(x => x.Id == courseId);
            Student studentEntity = await _dbContext.Students.SingleAsync(x => x.Id == studentId);

            courseEntity.Students.Add(studentEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourseVm>> GetAllCourses()
        {
            IEnumerable<Course> courseEntities = await _dbContext.Courses.ToListAsync();
            IEnumerable<CourseVm> courseVms = courseEntities.Select(x => CourseVm.FromEntity(x));
            return courseVms;
        }

        public async Task<CourseVm> GetCourseById(int id)
        {
            Course courseEntity = await _dbContext.Courses.SingleAsync(x => x.Id == id);
            CourseVm courseVm = CourseVm.FromEntity(courseEntity);
            return courseVm;
        }

        /// <summary>
        /// Get course details with students that are enrolled in this course.
        /// </summary>
        public async Task<CourseVm> GetCourseWithStudents(int courseId)
        {
            Course courseEntity = await _dbContext.Courses.
                Include(x => x.Students).
                SingleAsync(x => x.Id == courseId);
            CourseVm courseVm = CourseVm.FromEntity(courseEntity);
            return courseVm;
        }

        /// <summary>
        /// Get course details with students that aren't enrolled in this course.
        /// </summary>
        public async Task<CourseVm> GetCourseWithStudentsToAdd(int courseId)
        {
            Course courseEntity = await _dbContext.Courses.
                Include(x => x.Students).
                SingleOrDefaultAsync(x => x.Id == courseId);

            // Exclude students that are already enrolled in this course.
            IList<int> studentToExcludeIds = courseEntity.Students.Select(x => x.Id).ToList();

            IList<Student> studentsToAdd = await _dbContext.Students.
                Where(x => studentToExcludeIds.Contains(x.Id) == false).
                ToListAsync();
            // Course class is used as "add student model". Students property has different meaning. It represents students that currently aren't enrolled in course - potential course candidates.
            // Replace enrolled students with course candidates.
            courseEntity.Students = studentsToAdd;

            CourseVm addStudentVm = CourseVm.FromEntity(courseEntity);

            return addStudentVm;
        }

        public async Task RemoveStudentFromCourse(int courseId, int studentId)
        {
            Course courseEntity = await _dbContext.Courses.SingleAsync(x => x.Id == courseId);
            Student studentEntity = await _dbContext.Students.SingleAsync(x => x.Id == studentId);

            courseEntity.Students.Remove(studentEntity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
