using System;
using System.Linq;
using System.Reflection;
using DbUp;

namespace Tenisu.Database
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var connectionString =
                args.FirstOrDefault();
                
            Console.WriteLine($"Using connection string: {connectionString}");
            EnsureDatabase.For.MySqlDatabase(connectionString);
            var upgrader = DeployChanges.To
                .MySqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();
            var result = upgrader.PerformUpgrade();
            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                return -1;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value: "Success!");
            Console.ResetColor();
            return 0;
        }
    }
}