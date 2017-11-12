using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Demo01_StudentsAppEntityFramework6.Core
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(string cnnstr) : base(cnnstr)
        {
        }

        public IDbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasKey(s => s.Jmbag);
        }
    }
}
