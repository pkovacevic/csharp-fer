using System;

namespace Demo02_AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new { Ime = "Ivan", Prezime = "Horvat", DatumUpisa = new DateTime(2016, 12, 1) };
            var student2 = new { Ime = "Ivan", Prezime = "Horvat", DatumUpisa = new DateTime(2016, 12, 1) };
            var student3 = new { Ime = "Pero", Prezime = "D", DatumUpisa = new DateTime(2016, 12, 1) };

            // We can see compiler created the type once for all three students
            Console.WriteLine(student.GetType());
            Console.WriteLine(student2.GetType());
            Console.WriteLine(student3.GetType());

            // Equals method is overriden for us and works as we expect
            Console.WriteLine(student.Equals(student2));
            Console.WriteLine(student.Equals(student3));

            // ToString as well
            Console.WriteLine(student);
            
        }
    }
}