using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01_Basics.Models
{
    public class Professor : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Student> StudentsMentoring { get; set; }
        public List<Course> CoursesLecturing { get; set; }
    }
}
