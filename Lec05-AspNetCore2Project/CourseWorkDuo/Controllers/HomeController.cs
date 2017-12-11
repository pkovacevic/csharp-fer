using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CourseWorkDuo.ViewModels;
using CourseWorkDuo.Entities.Db;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CourseWorkDuo.Controllers
{
    public class HomeController : Controller
    {
        private readonly CourseWorkDbContext _dbContext;

        public HomeController(CourseWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DropAndReseedDb()
        {
            _dbContext.Database.Delete();

            var isAnyCourses = await _dbContext.Courses.AnyAsync();

            return Content(isAnyCourses.ToString());
        }

        public IActionResult Error()
        {
            return View(new ErrorVm { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
