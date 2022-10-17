using Newtonsoft.Json;
using System;
using System.IO;

namespace Zork
{
    public class Game
    {
        public World World { get; }

        [JsonIgnore]
        public Player Player { get; private set; }

        public Game(World world, Player player)
        {
            World = world;
            if (player != null)
            {
                Player = player;
            }
            else
            {
                Player = World.SpawnPlayer();
            };
        }

        public void Run()
        {
            Room previousRoom = null;
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(Player.Location);
                if (previousRoom != Player.Location)
                {
                    Console.WriteLine(Player.Location.Description);
                    previousRoom = Player.Location;
                }
                Console.Write(">");

                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;
                    case Commands.LOOK:
                        outputString = Player.Location.Description;
                        break;
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        Directions direction = (Directions)command;
                        outputString = Player.Move(direction) ? $"You moved {command}." : "The way is shut!";
                        break;
                    default:
                        outputString = "Unknown command.";
                        break;
                }

                Console.WriteLine(outputString);
            }
        }

        public static Game Load(string filename)
        {
            return JsonConvert.DeserializeObject<Game>(File.ReadAllText(filename));
        }

        private static Commands ToCommand(string commandString)
        {
            return Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        }
    }
}
