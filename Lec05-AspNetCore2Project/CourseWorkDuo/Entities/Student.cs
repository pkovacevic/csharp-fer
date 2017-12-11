using System;
using System.Collections.Generic;

namespace CourseWorkDuo.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StudentCode { get; set; }

        /// <summary>
        /// F - female
        /// M - male
        /// X - would rather not say
        /// </summary>
        public string Gender { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public IList<Course> Courses { get; set; }

        public Student()
        {
            Courses = new List<Course>();
        }
    }
}
