using System;
using System.Data.Entity;
using Tynamix.ObjectFiller;

namespace CourseWorkDuo.Entities.Db.Seed
{
    public class CourseWorkDbInitializer : DropCreateDatabaseIfModelChanges<CourseWorkDbContext>
    {
        private const int MIN_STUDENT_COUNT = 70;
        private const int MAX_STUDENT_COUNT = 130;

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

            // Don't forget to save changes to database. :)
            context.SaveChanges();
        }

    }
}
