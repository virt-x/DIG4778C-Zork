using System;
namespace Zork
{
    class Program
    {
        private static string CurrentRoom
        {
            get
            {
                return _rooms[_location.row, _location.column];
            }
        }

        private static readonly string[,] _rooms = {
            { "Rocky Trail", "South of House", "Canyon View" },
            { "Forest", "West of House", "Behind House" },
            { "Dense Woods", "North of House", "Clearing" }
        };
        private static (byte row, byte column) _location = (1, 1);

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.Write($"{CurrentRoom}\n> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;
                    case Commands.LOOK:
                        outputString = "This is an open field West of a white house, with a boarded front door.\n\nA rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        outputString = (Move(command) ? $"You moved {command}." : "The way is shut!");
                        break;
                    default:
                        outputString = "Unknown command.";
                        break;
                }
                Console.WriteLine(outputString);
            }
        }

        private static Commands ToCommand(string commandString)
        {
            return Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        }

        private static bool Move(Commands command)
        {
            switch (command)
            {
                case Commands.NORTH when _location.row < _rooms.GetLength(0) - 1:
                    _location.row++;
                    return true;

                case Commands.SOUTH when _location.row > 0:
                    _location.row--;
                    return true;

                case Commands.EAST when _location.column < _rooms.GetLength(1) - 1:
                    _location.column++;
                    return true;

                case Commands.WEST when _location.column > 0:
                    _location.column--;
                    return true;

                default:
                    return false;
            }
        }
    }
}
