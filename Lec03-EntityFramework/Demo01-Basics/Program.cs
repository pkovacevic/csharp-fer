using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo01_Basics.Database;
using Demo01_Basics.Models;

namespace Demo01_Basics
{
    class Program
    {

        // Preferable to keep in the configuration files.
        private const string ConnectionString =
            "Server=(localdb)\\mssqllocaldb;Database=UniversityDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        static void Main(string[] args)
        {
            SaveExample1();
            SaveExample2();
            SaveExample3();

            ReadExample1();

            UpdateExample1();
            UpdateExample2();
            UpdateExample3();

            DeleteExample1();
        }

        #region Save examples
        private static void SaveExample1()
        {
            using (var db = new UniversityDb(ConnectionString))
            {
                var ivan = new Student()
                {
                    FirstName = "Ivan",
                    LastName = "Horvat"
                };
                db.Students.Add(ivan);

                // Save changes is a required step which actually 
                // pushes changes to the database.
                //
                // Usually you want to use SaveChangesAsync() variant
                db.SaveChanges();

                // Ivan.Id before SaveChanges() => 0
                // Ivan.Id after SaveChanges() => 1...N
            }
        }

        private static void SaveExample2()
        {
            using (var db = new UniversityDb(ConnectionString))
            {
                try
                {
                    var pero = new Student();
                    db.Students.Add(pero);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException)
                {
                    // Calling at this point will cause DbEntityValidationException
                    // We tried to save a student without first name and last name set 
                    // (marked as required)
                }
            }
        }

        private static void SaveExample3()
        {
            using (var db = new UniversityDb(ConnectionString))
            {
                var ivica = new Professor()
                {
                    LastName = "Boticki",
                    FirstName = "Ivica"
                };

                var lovro = new Student()
                {
                    FirstName = "Lovro",
                    LastName = "Lovric",
                    Mentor = ivica
                };

                db.Students.Add(lovro);
                db.SaveChanges();
            }
        }
        #endregion

        #region Read examples
        private static void ReadExample1()
        {
            using (var db = new UniversityDb(ConnectionString))
            {
                // But why is the students mentoring list null?!
                List<Professor> professors = db.Professors.Where(p => p.StudentsMentoring.Count == 1).ToList();

                // Database operations can be expensive, 
                // if we want to fetch additional items from the database, we have to be explicit.
                List<Professor> professors2 = db.Professors.Where(p => p.StudentsMentoring.Count == 1)
                    .Include(p => p.StudentsMentoring)
                    .Include(p => p.CoursesLecturing)
                    .ToList();
            }
        }
        #endregion

        #region Update examples

        private static void UpdateExample3()
        {
            var studentFromGui = new Student()
            {
                FirstName = "User changed first name again",
                LastName = "User changed last name again",
                Id = 1
            };

            using (var db = new UniversityDb(ConnectionString))
            {
                // Mark entry as modified. Context will start tracking it.
                db.Entry(studentFromGui).State = EntityState.Modified;
                // Let EF update everything...
                db.SaveChanges();
            }
        }

        private static void UpdateExample2()
        {
            // For example, we got a student change request from UI
            // User changed the student with ID = 1 and sent us the object

            var studentFromGui = new Student()
            {
                FirstName = "User changed first name",
                LastName = "User changed last name",
                Id = 1
            };

            // We need to update student with ID = 1 with the new data
            using (var db = new UniversityDb(ConnectionString))
            {
                // One way... not so practical (check update example 3 for better approach):

                // We are using .First this time... maybe we want the exception
                // if user was changing non existing student
                var studentFromDb = db.Students.First(s => s.Id == studentFromGui.Id);
                studentFromDb.FirstName = studentFromGui.FirstName;
                studentFromDb.LastName = studentFromGui.LastName;
                // ...
                db.SaveChanges();

                // What if we add a new property to student? we have to remember to update
                // this method as well. And you will forget :)
            }
        }

        private static void UpdateExample1()
        {
            using (var db = new UniversityDb(ConnectionString))
            {
                // or shorter: .FirstOrDefault(s => s.Mentor != null)
                var student = db.Students.Where(s => s.Mentor != null).FirstOrDefault();
                if (student != null)
                {
                    student.FirstName = "Hehe";

                    db.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete examples
        private static void DeleteExample1()
        {
            using (var db = new UniversityDb(ConnectionString))
            {
                var studentToRemove = db.Students.LastOrDefault();
                if (studentToRemove != null)
                {
                    db.Students.Remove(studentToRemove);
                    db.SaveChanges();
                }
            }
        }

        #endregion






    }
}
