namespace Hw2_Tests.Assignment1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            if (obj is Student)
            {
                return (obj as Student).Jmbag == Jmbag;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}