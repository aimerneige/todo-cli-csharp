using System;
using System.Linq;
using todo_cli.Model;
using todo_cli.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace todo_cli.Database.Provider
{
    public class TodoProviders
    {
        private readonly TodoContext dbContext;

        public TodoProviders(TodoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void InsertTodo(Todo todo)
        {
            dbContext.Add(todo);
            dbContext.SaveChanges();
        }

        public IOrderedQueryable<Todo> GetAllTodos()
        {
            return dbContext.Todos.OrderBy(t => t.Id);
        }

        public Todo GetTodoWithId(int id)
        {
            return dbContext.Todos.Where(t => t.Id == id).FirstOrDefault();
        }

        public void DeleteTodoWithId(int id)
        {
            dbContext.Todos.Remove(GetTodoWithId(id));
            dbContext.SaveChanges();
        }

        public void UpdateTodo(int id, Todo newTodo)
        {
            var todo = GetTodoWithId(id);
            Todo.CopyProp(todo, newTodo);
            dbContext.SaveChanges();
        }
    }
}
