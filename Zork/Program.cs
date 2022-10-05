using System;
using System.IO;
using Newtonsoft.Json;

namespace Zork
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

            Game game = Game.Load(gameFilename);
            Console.WriteLine("Welcome to Zork!");
            game.Run();
        }
    }
}