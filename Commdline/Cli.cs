using System;
using CommandLine;
using System.Linq;
using todo_cli.Model;
using todo_cli.Database.Context;
using todo_cli.Database.Provider;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace todo_cli.Commdline
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

            ListTodos();
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {

        }

        private static void ListTodos()
        {
            List<Todo> todos = todoProviders.GetAllTodos().ToList();
            Console.WriteLine("=====================================================");
            foreach (Todo todo in todos)
            {
                Console.WriteLine($"{todo.Id} {todo.DoneIcon()} {todo.TimeDisplayResponseDone()}\t{todo.Title}");
            }
            Console.WriteLine("=====================================================");
        }

        private static void AddTodo()
        {
            Console.Write("Please Input Title:");
            var title = Console.ReadLine();
            Console.Write("Please Input Detail:");
            var detail = Console.ReadLine();
            Todo todo = new Todo
            {
                Title = title,
                Detail = detail,
                CreateTime = DateTime.Now,
                EndTime = DateTime.Now,
                Done = false
            };
            todoProviders.InsertTodo(todo);
        }

        private static void CatTodo()
        {
            ListTodos();
            Console.Write("Please Input Id:");
            int id;
            var id_string = Console.ReadLine();
            try {
                id = Int32.Parse(id_string);
            } catch (FormatException) {
                Console.WriteLine("Not a int");
                return;
            }
            // TODO wrong id
            Todo todo = todoProviders.GetTodoWithId(id);
            Console.WriteLine("=====================================================");
            Console.WriteLine($"Title:\t{todo.Title}");
            Console.WriteLine($"{todo.DoneIcon()} {todo.TimeDisplayResponseDone()}");
            Console.WriteLine($"Detail:\n{todo.Detail}");
            Console.WriteLine("=====================================================");
        }

        private static void DoneTodo()
        {
            ListTodos();
            Console.Write("Please Input Id:");
            int id;
            var id_string = Console.ReadLine();
            try {
                id = Int32.Parse(id_string);
            } catch (FormatException) {
                Console.WriteLine("Not a int");
                return;
            }
            // TODO wrong id
            Todo todo = todoProviders.GetTodoWithId(id);
            todo.EndTime = DateTime.Now;
            todo.Done = true;
            todoProviders.UpdateTodo(id, todo);
        }

        private static void DeleteTodo()
        {
            ListTodos();
            Console.Write("Please Input Id:");
            int id;
            var id_string = Console.ReadLine();
            try {
                id = Int32.Parse(id_string);
            } catch (FormatException) {
                Console.WriteLine("Not a int");
                return;
            }
            // TODO wrong id
            todoProviders.DeleteTodoWithId(id);
        }
    }
}
