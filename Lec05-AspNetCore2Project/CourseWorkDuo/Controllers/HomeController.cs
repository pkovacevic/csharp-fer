using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CourseWorkDuo.ViewModels;

namespace CourseWorkDuo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorVm { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
