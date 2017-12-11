using CourseWorkDuo.Entities.Db.Seed;
using Microsoft.AspNetCore.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Diagnostics;

namespace CourseWorkDuo.Entities.Db
{
    public class CourseWorkDbContext : DbContext
    {
        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        // Inject hosting environment to check if in development or production environment.
        public CourseWorkDbContext(string connectionString, IHostingEnvironment env) : base(connectionString)
        {
            if (env.IsDevelopment())
            {
                // Log SLQ statements to debug console during development
                Database.Log = logRecord => Debug.WriteLine(logRecord);

                // Don't use database migrations during development. Drop database if schema changes. Speeds up development.
                Database.SetInitializer(new CourseWorkDbInitializer());
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().Property(x => x.FirstName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Student>().Property(x => x.LastName).IsRequired().HasMaxLength(255);
            // Create unique index on StudentCode.
            modelBuilder.Entity<Student>().
                Property(p => p.StudentCode).
                IsRequired().
                HasMaxLength(20).
                HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Student_StudentCode")
                    {
                        IsUnique = true,
                    }
                    )
                );
            modelBuilder.Entity<Student>().Property(x => x.Gender).IsRequired().HasMaxLength(1);

            modelBuilder.Entity<Course>().Property(x => x.Name).IsRequired().HasMaxLength(255);
        }
    }
}