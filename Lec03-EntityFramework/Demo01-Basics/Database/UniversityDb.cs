using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo01_Basics.Models;

namespace Demo01_Basics.Database
{
    public class UniversityDb : DbContext
    {
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Professor> Professors { get; set; }
        public IDbSet<Course> Courses { get; set; }

        public UniversityDb(string cnnstr) : base(cnnstr)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Student>().Property(s => s.FirstName).IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.LastName).IsRequired();
            modelBuilder.Entity<Student>().HasOptional(s => s.Mentor).WithMany(m => m.StudentsMentoring);
            modelBuilder.Entity<Student>().HasMany(s => s.CoursesAttending).WithMany(m => m.StudentsAttending);
            modelBuilder.Entity<Student>().HasMany(s => s.CoursesFinished).WithMany(m => m.StudentAttended);

            modelBuilder.Entity<Course>().HasKey(c => c.Id);
            modelBuilder.Entity<Course>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<Course>().HasMany(c => c.Lecturers).WithMany(p => p.CoursesLecturing);

            modelBuilder.Entity<Professor>().HasKey(s => s.Id);
            modelBuilder.Entity<Professor>().Property(s => s.FirstName).IsRequired();
            modelBuilder.Entity<Professor>().Property(s => s.LastName).IsRequired();
        }
    }
}
