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

        public async Task<IActionResult> AddStudent(int courseId)
        {
            CourseVm addStudentModel = await _courseRepository.GetCourseWithStudentsToAdd(courseId);

            return View(addStudentModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(int courseId, int studentId)
        {
            await _courseRepository.AddStudentToCourse(courseId, studentId);

            var messageVm = new MessageVm("Student was sucessfully enrolled in course.");

            // Add courseId and msg to query string.
            // Ex: courseworkduo.edu/Entollment/Index?courseId=42&msg=some_msg.
            return RedirectToAction("Index", new { courseId, messageVm.Msg });
        }
    }
}