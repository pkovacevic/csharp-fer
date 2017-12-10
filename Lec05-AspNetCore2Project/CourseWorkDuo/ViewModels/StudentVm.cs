using CourseWorkDuo.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CourseWorkDuo.ViewModels
{
    public class StudentVm
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [RegularExpression(@"\d+", ErrorMessage = "Student code can contain numbers only. Please make sure that input doesn't contain any white space.")]
        [Display(Name = "Student Code")]
        public string StudentCode { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string GenderValue { get; set; }

        public string GenderText
        {
            get
            {
                return GetGenderText(GenderValue);
            }
        }

        public static string GetGenderText(string genderValue)
        {
            if (string.IsNullOrEmpty(genderValue))
            {
                return "";
            }

            string text = GetGenderOptions().
                FirstOrDefault(x => x.Key.ToUpper() == genderValue.ToUpper()).
                Value ?? "";
            return text;
        }

        public static IEnumerable<KeyValuePair<string, string>> GetGenderOptions()
        {
            var optionItems = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("", "-- Please select gender --"),
                new KeyValuePair<string, string>("F", "Female"),
                new KeyValuePair<string, string>("M", "Male"),
                new KeyValuePair<string, string>("X", "Would rather not say"),
            };

            return optionItems;
        }

        public static StudentVm FromEntity(Student entity)
        {
            StudentVm vm = new StudentVm
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                StudentCode = entity.StudentCode,
                GenderValue = entity.Gender,
            };

            return vm;
        }
    }
}
