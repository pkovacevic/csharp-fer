using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseWorkDuo.ViewModels;
using CourseWorkDuo.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CourseWorkDuo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public async Task<IActionResult> Index()
        {
            IList<StudentVm> students = await _studentRepo.GetStudentList();

            return View(students);
        }

        public async Task<IActionResult> Details(int id)
        {
            StudentVm student = await _studentRepo.GetSudentById(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await _studentRepo.Remove(id);

            var messageVm = new MessageVm("Student is removed.");
            return RedirectToAction("Index", messageVm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            StudentVm studentVm = await _studentRepo.GetSudentById(id);
            studentVm.GenderOptions = GetGenderOptions();

            return View(studentVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentVm vm)
        {
            if (ModelState.IsValid == false)
            {
                vm.GenderOptions = GetGenderOptions();
                return View(vm);
            }

            await _studentRepo.Edit(vm);

            return RedirectToAction(nameof(Details), new { id = vm.Id });
        }

        private static IList<SelectListItem> GetGenderOptions()
        {
            IList<SelectListItem> options = StudentVm.GetGenderOptions().
                Select(x => new SelectListItem { Text = x.Value, Value = x.Key }).
                ToList();
            return options;
        }
    }
}
