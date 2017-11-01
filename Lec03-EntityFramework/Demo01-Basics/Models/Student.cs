using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01_Basics.Models
{
    public class Student : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateGraduated { get; set; }

        public string Name => $"{FirstName} {LastName}";
        public bool HasGraduated => DateGraduated.HasValue;

        public List<Course> CoursesAttending { get; set; }
        public List<Course> CoursesFinished { get; set; }
        public Professor Mentor { get; set; }
    }
}
