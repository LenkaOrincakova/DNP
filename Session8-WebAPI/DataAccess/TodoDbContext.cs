using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodosWebAPI.Models;

namespace TodosWebAPI.DataAccess
{
    public class TodoDbContext : DbContext 
    {
            public DbSet<Todo> Todos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //name of database
            optionsBuilder.UseSqlite("Data Source = Todos.db");
        }
    }
}
