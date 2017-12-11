using System;
using System.Data.Entity;
using Tynamix.ObjectFiller;

namespace CourseWorkDuo.Entities.Db.Seed
{
    public class CourseWorkDbInitializer : DropCreateDatabaseIfModelChanges<CourseWorkDbContext>
    {
        private const int MIN_STUDENT_COUNT = 70;
        private const int MAX_STUDENT_COUNT = 130;

        private const int MIN_COURSE_COUNT = 7;
        private const int MAX_COURSE_COUNT = 13;

        protected override void Seed(CourseWorkDbContext context)
        {
            // Seed some students.
            var randomStudentGenerator = new Filler<Student>().SetupStudentGenerator();

            var rand = new Random();

            var studentCount = rand.Next(MIN_STUDENT_COUNT, MAX_STUDENT_COUNT);
            for (int i = 0; i < studentCount; i++)
            {
                context.Students.Add(randomStudentGenerator.Create());
            }

            // Seed some courses.
            var randomCourseGenerator = new Filler<Course>().SetupRandomCourseGenerator();

            var courseCount = rand.Next(MIN_COURSE_COUNT, MAX_COURSE_COUNT);
            for (int i = 0; i < courseCount; i++)
            {
                context.Courses.Add(randomCourseGenerator.Create());
            }

            // Don't forget to save changes to database. :)
            context.SaveChanges();
        }

    }
}
