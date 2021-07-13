using System;
using CommandLine;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace todo_cli
{
    public class Cli
    {
        private static readonly TodoProviders todoProviders = new TodoProviders(new TodoContext());

        private class Options
        {
            [Option('l', "list", Required = false, HelpText = "List all saved todos.")]
            public bool ListOpt { get; set; }

            [Option('a', "add", Required = false, HelpText = "Add new todo to database.")]
            public bool AddOpt { get; set; }

            [Option('c', "cat", Required = false, HelpText = "View one todo's details.")]
            public bool CatOpt { get; set; }

            [Option('e', "done", Required = false, HelpText = "Mark one todo done.")]
            public bool DoneOpt { get; set; }

            [Option('d', "delete", Required = false, HelpText = "Delete one todo record.")]
            public bool DeleteOpt { get; set; }
        }

        public static void ParseArguments(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
        }

        private static void RunOptions(Options opts)
        {
            // handle options
            if (opts.ListOpt)
            {
                ListTodos();
                return;
            }

            if (opts.AddOpt)
            {
                AddTodo();
                return;
            }

            if (opts.CatOpt)
            {
                CatTodo();
                return;
            }

            if (opts.DoneOpt)
            {
                DoneTodo();
                return;
            }

            if (opts.DeleteOpt)
            {
                DeleteTodo();
                return;
            }
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            Console.WriteLine("Wrong args!");
        }

        private static void ListTodos()
        {
            Console.WriteLine("List Todos");
            // List<Todo> todos = todoProviders.GetAllTodos().ToList();
            // foreach (Todo todo in todos)
            // {
            //     Console.WriteLine($"{todo.DoneIcon()} {todo.TimeDisplayResponseDone()}\t{todo.Title}");
            // }
        }

        private static void AddTodo()
        {
            Console.WriteLine("Add Todos");
            // string title = "Title";
            // string detail = "Detail";
            // // TODO read from terminal
            // Todo todo = new Todo
            // {
            //     Title = title,
            //     Detail = detail,
            //     CreateTime = DateTime.Now,
            //     EndTime = DateTime.Now,
            //     Done = false
            // };
            // todoProviders.InsertTodo(todo);
        }

        private static void CatTodo()
        {
            Console.WriteLine("Cat Todos");
            // int id = 1;
            // // TODO get id from terminal
            // Todo todo = todoProviders.GetTodoWithId(id);
            // Console.WriteLine($"{todo.DoneIcon()} {todo.TimeDisplayResponseDone()}\t{todo.Title}\t");
            // Console.WriteLine(todo.Detail);
        }

        private static void DoneTodo()
        {
            Console.WriteLine("Done Todos");
            // int id = 1;
            // // TODO get id from terminal
            // Todo todo = todoProviders.GetTodoWithId(id);
            // todo.EndTime = DateTime.Now;
            // todo.Done = true;
            // todoProviders.UpdateTodo(id, todo);
        }

        private static void DeleteTodo()
        {
            Console.WriteLine("Delete Todos");
            // int id = 1;
            // // TODO get id from terminal
            // todoProviders.DeleteTodoWithId(id);
        }
    }
}
