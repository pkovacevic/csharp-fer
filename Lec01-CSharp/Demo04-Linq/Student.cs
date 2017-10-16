using System;

namespace Demo04_Linq
{
    public class Student
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public Student(string name)
        {
            Name = name;
            DateOfBirth = DateTime.Now;
        }
    }
}