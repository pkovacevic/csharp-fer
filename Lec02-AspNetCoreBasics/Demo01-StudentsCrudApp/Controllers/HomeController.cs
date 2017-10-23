using System.Threading.Tasks;
using Demo01_StudentsCrudApp.Core;
using Microsoft.AspNetCore.Mvc;

namespace Demo01_StudentsCrudApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Students()
        {
            var students = await _studentRepository.GetAllAsync();
            return View(students);
        }


        /// <summary>
        /// Home/Student/003457336
        /// </summary>
        [HttpGet("{jmbag}")]
        public async Task<IActionResult> Student(string jmbag)
        {
            var student = await _studentRepository.GetAsync(jmbag);
            return View(student);

        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student s)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.AddAsync(s);
                return RedirectToAction("Students");
            }
            return View(s);
        }


        public IActionResult Error()
        {
            return View();
        }


    }
}