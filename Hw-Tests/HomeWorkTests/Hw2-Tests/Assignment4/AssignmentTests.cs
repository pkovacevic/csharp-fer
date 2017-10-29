using System;
using System.Linq;
using Hw2_Tests.Assignment1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hw2_Tests.Assignment4
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void Linq1_1Point()
        {
            int[] integers = new[] { 1, 3, 3, 4, 2, 2, 2, 3, 3, 4, 5 };

            string[] result = HomeworkLinqQueries.Linq1(integers);
            
            Assert.AreEqual("broj 1 ponavlja se 1 puta", result[0].ToLower());
            Assert.AreEqual("broj 2 ponavlja se 3 puta", result[1].ToLower());
            Assert.AreEqual("broj 3 ponavlja se 4 puta", result[2].ToLower());
            Assert.AreEqual("broj 4 ponavlja se 2 puta", result[3].ToLower());
            Assert.AreEqual("broj 5 ponavlja se 1 puta", result[4].ToLower());
        }
        
        [TestMethod]
        public void Linq21_1Point()
        {
            var universities = GetAllCroatianUniversities();

            University[] maleOnlyUniversities = HomeworkLinqQueries.Linq2_1(universities);
            
            Assert.AreEqual(2, maleOnlyUniversities.Length);
            Assert.IsTrue(maleOnlyUniversities.Any(u => u.Name == "Uni1"));
            Assert.IsTrue(maleOnlyUniversities.Any(u => u.Name == "Uni6"));
        }
        
        [TestMethod]
        public void Linq22_1Point()
        {
            var universities = GetAllCroatianUniversities();

            University[] underAverageStudentNumberUniversities = HomeworkLinqQueries.Linq2_2(universities);
            
            Assert.AreEqual(4, underAverageStudentNumberUniversities.Length);
        }
        
        [TestMethod]
        public void Linq23_2Points()
        {
            var universities = GetAllCroatianUniversities();

            Student[] getAllStudents = HomeworkLinqQueries.Linq2_3(universities);
            
            Assert.AreEqual(31, getAllStudents.Length);
        }
        
        [TestMethod]
        public void Linq24_2Points()
        {
            var universities = GetAllCroatianUniversities();

            Student[] oneGenderUniversityStudents = HomeworkLinqQueries.Linq2_4(universities);
            
            Assert.AreEqual(7, oneGenderUniversityStudents.Length);
            Assert.IsTrue(oneGenderUniversityStudents.Any(s => s.Jmbag == "1"));
            Assert.IsTrue(oneGenderUniversityStudents.Any(s => s.Jmbag == "2"));
            Assert.IsTrue(oneGenderUniversityStudents.Any(s => s.Jmbag == "30"));
            Assert.IsTrue(oneGenderUniversityStudents.Any(s => s.Jmbag == "31"));
            Assert.IsTrue(oneGenderUniversityStudents.Any(s => s.Jmbag == "32"));
            Assert.IsTrue(oneGenderUniversityStudents.Any(s => s.Jmbag == "2"));
            Assert.IsTrue(oneGenderUniversityStudents.Any(s => s.Jmbag == "3"));
        }
        
        [TestMethod]
        public void Linq25_3Points()
        {
            var universities = GetAllCroatianUniversities();

            Student[] studentsOnMultipleUniversities = HomeworkLinqQueries.Linq2_5(universities);
            
            Assert.AreEqual(3, studentsOnMultipleUniversities.Length);
            Assert.IsTrue(studentsOnMultipleUniversities.Any(s => s.Jmbag == "1"));
            Assert.IsTrue(studentsOnMultipleUniversities.Any(s => s.Jmbag == "2"));
            Assert.IsTrue(studentsOnMultipleUniversities.Any(s => s.Jmbag == "4"));
        }
        


        private University[] GetAllCroatianUniversities()
        {
            return new  University[]
            {
                new University()
                {
                    Name = "Uni1",
                    Students = new Student[]
                    {
                        new Student("1", "1"){Gender = Gender.Male},
                        new Student("2", "2"){Gender = Gender.Male},
                    }
                },
                new University()
                {
                    Name = "Uni2",
                    Students = new Student[]
                    {
                        new Student("3", "3"){Gender = Gender.Female},
                        new Student("4", "4"){Gender = Gender.Female},
                    }
                },
                new University()
                {
                    Name = "Uni3",
                    Students = new Student[]
                    {
                        new Student("2", "2"){Gender = Gender.Male},
                        new Student("5", "5"){Gender = Gender.Female},
                        new Student("6", "6"){Gender = Gender.Female},
                        new Student("7", "7"){Gender = Gender.Female},
                        new Student("8", "8"){Gender = Gender.Female},
                        new Student("9", "9"){Gender = Gender.Male},
                        new Student("10", "10"){Gender = Gender.Male},
                        new Student("11", "11"){Gender = Gender.Male},
                    }
                },
                new University()
                {
                    Name = "Uni4",
                    Students = new Student[]
                    {
                        new Student("12", "12"){Gender = Gender.Male},
                        new Student("13", "13"){Gender = Gender.Male},
                        new Student("14", "14"){Gender = Gender.Female},
                    }
                },
                new University()
                {
                    Name = "Uni5",
                    Students = new Student[]
                    {
                        new Student("1", "1"){Gender = Gender.Male},
                        new Student("4", "4"){Gender = Gender.Female},
                        new Student("16", "16"){Gender = Gender.Female},
                        new Student("17", "17"){Gender = Gender.Female},
                        new Student("18", "18"){Gender = Gender.Female},
                        new Student("19", "19"){Gender = Gender.Female},
                        new Student("20", "20"){Gender = Gender.Female},
                        new Student("21", "21"){Gender = Gender.Female},
                        new Student("22", "22"){Gender = Gender.Female},
                        new Student("23", "23"){Gender = Gender.Female},
                        new Student("24", "24"){Gender = Gender.Female},
                        new Student("25", "25"){Gender = Gender.Male},
                        new Student("26", "26"){Gender = Gender.Male},
                        new Student("27", "27"){Gender = Gender.Male},
                        new Student("28", "28"){Gender = Gender.Male},
                        new Student("29", "29"){Gender = Gender.Male},

                    }
                },
                new University()
                {
                    Name = "Uni6",
                    Students = new Student[]
                    {
                        new Student("1", "1"){Gender = Gender.Male},
                        new Student("30", "30"){Gender = Gender.Male},
                        new Student("31", "31"){Gender = Gender.Male},
                        new Student("32", "32"){Gender = Gender.Male},
                    }
                }
                
            };
        }
    }
    
    
}