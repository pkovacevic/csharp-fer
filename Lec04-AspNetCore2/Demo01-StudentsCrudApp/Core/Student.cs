using System.ComponentModel.DataAnnotations;

namespace Demo01_StudentsCrudApp.Core
{
    public class Student
    {
        [Required, MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Jmbag { get; set; }
    }
}