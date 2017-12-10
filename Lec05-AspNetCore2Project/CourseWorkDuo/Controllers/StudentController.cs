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
using CourseWorkDuo.ViewModels;
using CourseWorkDuo.Repositories;

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
            StudentVm student = await _studentRepo.Details(id);

            return View(student);
        }

    }
}
