using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Demo01WebTechnologies.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo01WebTechnologies.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult GetStudents()
        {
            var students = new List<Student>()
            {
                new Student("001231242", "Ivan", "Horvat"),
                new Student("001231242", "Pero", "Peric"),
                new Student("001231242", "Martina", "Kovacevic")
            };

            return new ObjectResult(students);
        }

    }


}
