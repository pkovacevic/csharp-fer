using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Demo02_WithMigrationsExample.Data2
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class MyEf6Context : System.Data.Entity.DbContext
    {
        public IDbSet<Todo> Todos { get; set; }

        public MyEf6Context(string cnnstr) : base(cnnstr)
        {
            
        }
    }
}
