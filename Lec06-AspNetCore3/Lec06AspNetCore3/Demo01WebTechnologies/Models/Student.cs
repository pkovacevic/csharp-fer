using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo01WebTechnologies.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Jmbag { get; set; }

        public Student(string jmbag, string firstName, string lastName)
        {
            Jmbag = jmbag;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
