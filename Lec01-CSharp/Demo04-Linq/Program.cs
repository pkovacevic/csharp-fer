using System;
using System.Collections.Generic;

namespace Demo04_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringCollection = { "aaa", "b", "cc", "dddd" };

            // naive approach. for every required any condition, we create a separate implementation
            bool anyStartsWithL = stringCollection.AnyStartsWithL();
            bool anyStartsWithM = stringCollection.AnyStartsWithM();

            // better approach. whoever wants to use any method, he has to provide 
            // a function he'd like us to check the any condition for.
            bool betterAny = stringCollection.Any(s => s.StartsWith("l"));
            bool betterAny2 = stringCollection.Any(s => s.StartsWith("m"));
            bool betterAny3 = stringCollection.Any(s => s.StartsWith("a"));
            bool betterAny4 = stringCollection.Any(s => s.Length > 2);

            // even better approach. why limit any to work only with strings?
            // make it generic.
            var students = new List<Student>(){
                new Student("Luka"),
                new Student("Mario"),
                new Student("Igor"),
            };
                
            bool anyLukas = students.Any(s => s.Name == "Luka");
            bool anyBirthdaysToday = students.Any(s => s.DateOfBirth.Month == DateTime.Today.Month && s.DateOfBirth.Day == DateTime.Today.Day);
        }
    }
}