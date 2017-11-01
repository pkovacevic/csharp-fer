using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hw2_Tests.Assignment1
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void Case1_4points()
        {
            var topStudents = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567"),
                new Student("Luka", jmbag: "3274272"),
                new Student("Ana", jmbag: "9382832")
            };
            var ivan = new Student("Ivan", jmbag: "001234567");
            Assert.IsTrue(topStudents.Contains(ivan));
        }

        [TestMethod]
        public void Case2_4points()
        {
            var list = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567"),
                new Student("Ivan", jmbag: "001234567")
            };
            var distinctStudentsCount = list.Distinct().Count();
            Assert.AreEqual(1, distinctStudentsCount);
        }

        [TestMethod]
        public void Case3_2points()
        {
            var topStudents = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567"),
                new Student("Luka", jmbag: "3274272"),
                new Student("Ana", jmbag: "9382832")
            };
            var ivan = new Student("Ivan", jmbag: "001234567");
            Assert.IsTrue(topStudents.Any(s => s == ivan));
        }
    }
}