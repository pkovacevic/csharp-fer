using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseWorkDuo.Models;
using CourseWorkDuo.Entities.Db;
using System.Data.Entity;
using CourseWorkDuo.Entities;

namespace CourseWorkDuo.Controllers
{
    public class StudentController : Controller
    {
        private readonly CourseWorkDbContext _dbContext;

        public StudentController(CourseWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            IList<Student> students = await _dbContext.Students.ToListAsync();

            return View(students);
        }

        public async Task<IActionResult> Details(int id)
        {
            Student student = await _dbContext.Students.SingleAsync(x => x.Id == id);

            return View(student);
        }

        public IActionResult Tinker()
        {
            _dbContext.Database.Delete();

            // Test database access. 
            var val = _dbContext.Students.Count();
 
            // 1 should be displayed on screen at url: Student/Tinker
            return Content(val.ToString());
        }
    }
}
