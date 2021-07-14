using System;
using todo_cli.Model;
using Microsoft.EntityFrameworkCore;

namespace todo_cli.Database.Context
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder options
        )
        {
            options.UseSqlite(@"Data Source=./todo.db");
        }
    }
}
