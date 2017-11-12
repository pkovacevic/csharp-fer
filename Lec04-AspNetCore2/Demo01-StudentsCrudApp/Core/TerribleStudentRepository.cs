using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Demo01_StudentsCrudApp.Core
{
    /// <summary>
    /// Terrible student repository. Stores all data 
    /// in JSON format in a file on a server storage. 
    /// 
    /// Inefficient and comes with critical concurrency issues. 
    /// We will provide a better implementation after the databases lecture.
    /// </summary>
    public class TerribleStudentRepository : IStudentRepository
    {
        public async Task<Student> AddAsync(Student s)
        {
            var students = await GetAllAsync();
            students.Add(s);
            await SaveAsync(students);
            return s;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            if (!File.Exists(DatabasePath))
            {
                // If database doesn't exist, nothing has been saved yet.
                // Just return an empty list.
                return new List<Student>();
            }
            
            // Fetch content from db file and deserialize it to List<Student>
            var studentsSerialized = await File.ReadAllTextAsync(DatabasePath);
            return JsonConvert.DeserializeObject<List<Student>>(studentsSerialized);
        }

        public async Task<Student> GetAsync(string jmbag)
        {
            return (await GetAllAsync()).FirstOrDefault(s => s.Jmbag == jmbag);
        }

        #region Private methods

        private string DatabasePath
        {
            get { return $"{AppDomain.CurrentDomain.BaseDirectory}/StudentDatabase.json"; }
        }

        private async Task SaveAsync(List<Student> students)
        {
            using (var file = File.CreateText(DatabasePath))
            {
                // Serialize students and save the string in database file
                var studentsSerialized = JsonConvert.SerializeObject(students);
                await file.WriteAsync(studentsSerialized);
            }
        }

        #endregion
    }
}