using CourseWorkDuo.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CourseWorkDuo.ViewModels
{
    public class CourseVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<StudentVm> Students { get; private set; }

        public static CourseVm FromEntity(Course entity)
        {
            CourseVm vm = new CourseVm
            {
                Id = entity.Id,
                Name = entity.Name,
                Students = entity.Students.Select(x => StudentVm.FromEntity(x)).ToList(),
            };
            return vm;
        }
    }
}
