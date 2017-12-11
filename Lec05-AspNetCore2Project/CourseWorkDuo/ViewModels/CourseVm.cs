using CourseWorkDuo.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CourseWorkDuo.ViewModels
{
    public class CourseVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static CourseVm FromEntity(Course entity)
        {
            CourseVm vm = new CourseVm
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            return vm;
        }
    }
}
