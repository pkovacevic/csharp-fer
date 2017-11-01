using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01_Basics.Models
{
    public class Course : Entity
    {
        public string Name { get; set; }
        public List<Student> StudentsAttending { get; set; }
        public List<Student> StudentAttended { get; set; }
        public List<Professor> Lecturers { get; set; }
    }
}
