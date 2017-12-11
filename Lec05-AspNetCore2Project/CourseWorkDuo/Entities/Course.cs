using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWorkDuo.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<Student> Students { get; set; }

        public Course()
        {
            Students = new List<Student>();
        }
    }
}
