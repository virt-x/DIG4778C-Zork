using System;
using System.IO;
using Zork.Common;

namespace Zork.CommandLine
{
    class Program
    {
        private enum CommandLineArguments
        {
            GameFilename = 0
        }
        static void Main(string[] args)
        {
            const string defaultGameFilename = @"Content\Zork.json";
            string gameFilename = (args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : defaultGameFilename);

            Game game = Game.Load(File.ReadAllText(gameFilename));
            Console.WriteLine("Welcome to Zork!");

            var input = new ConsoleInputService();
            var output = new ConsoleOutputService();
            game.Run(input, output);

            while (game.IsRunning)
            {
                input.ProcessInput();
            }
        }
    }
}