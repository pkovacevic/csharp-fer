using System;

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
    }
}
