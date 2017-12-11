using CourseWorkDuo.Repositories;
using CourseWorkDuo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseWorkDuo.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<CourseVm> courses = await _courseRepository.GetAllCourses();

            return View(courses);
        }

        public async Task<IActionResult> Details(int id)
        {
            CourseVm course = await _courseRepository.GetCourseById(id);

            return View(course);
        }

    }
}
