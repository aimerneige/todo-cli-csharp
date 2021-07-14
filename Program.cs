using todo_cli.Commdline;

namespace todo_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Cli.ParseArguments(args);
        }
    }
}
