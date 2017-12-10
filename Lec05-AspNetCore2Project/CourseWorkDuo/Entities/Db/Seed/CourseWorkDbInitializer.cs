using System.Data.Entity;

namespace CourseWorkDuo.Entities.Db.Seed
{
    public class CourseWorkDbInitializer : DropCreateDatabaseIfModelChanges<CourseWorkDbContext>
    {
        protected override void Seed(CourseWorkDbContext context)
        {
            // TODO: Not implemented yet.

            // Don't forget to save changes to database. :)
            context.SaveChanges();
        }

    }
}
