using CourseWorkDuo.Entities.Db;
using CourseWorkDuo.Repositories;
using CourseWorkDuo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWorkDuo.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public EnrollmentController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IActionResult> Index(int courseId)
        {
            CourseVm course = await _courseRepository.GetCourseWithStudents(courseId);
            return View(course);
        }

    }
}