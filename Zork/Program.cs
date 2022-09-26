using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zork
{
    class Program
    {
        private static readonly Room[,] _rooms = {
            { new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View") },
            { new Room("Forest"), new Room("West of House"), new Room("Behind House") },
            { new Room("Dense Woods"), new Room("North of House"), new Room("Clearing") }
        };
        private static readonly Dictionary<string, Room> RoomMap;
        private static (byte row, byte column) _location = (1, 1);

        private static Room CurrentRoom
        {
            get
            {
                return _rooms[_location.row, _location.column];
            }
        }

        static Program()
        {
            RoomMap = new Dictionary<string, Room>();
            foreach (Room room in _rooms)
            {
                RoomMap[room.Name] = room;
            }
        }

        private enum CommandLineArguments
        {
            RoomsFilename = 0
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            const string defaultRoomsFilename = "Content\\Rooms.txt";
            string roomsFilename = (args.Length > 0 ? args[(int)CommandLineArguments.RoomsFilename] : defaultRoomsFilename);
            InitializeRoomDescriptions(roomsFilename);

            Room previousRoom = null;
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom);
                if (previousRoom != CurrentRoom)
                {
                    Console.WriteLine(CurrentRoom.Description);
                    previousRoom = CurrentRoom;
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
                        outputString = CurrentRoom.Description;
                        break;
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        outputString = Move(command) ? $"You moved {command}." : "The way is shut!";
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


        private enum Fields
        {
            Name = 0,
            Description
        }
        private static void InitializeRoomDescriptions(string roomsFilename)
        {
            const string fieldDelimiter = "##";
            const int expectedFieldCount = 2;

            var roomQuery = from line in File.ReadLines(roomsFilename)
                            let fields = line.Split(fieldDelimiter)
                            where fields.Length == expectedFieldCount
                            select (Name: fields[(int)Fields.Name],
                                    Description: fields[(int)Fields.Description]);

            foreach (var (Name, Description) in roomQuery)
            {
                RoomMap[Name].Description = Description;
            }
        }
    }
}