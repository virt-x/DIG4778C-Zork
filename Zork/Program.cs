using System;
using System.Collections.Generic;

namespace Zork
{
    class Program
    {
        private static readonly Room[,] _rooms = {
            { new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View") },
            { new Room("Forest"), new Room("West of House"), new Room("Behind House") },
            { new Room("Dense Woods"), new Room("North of House"), new Room("Clearing") }
        };
        private static (byte row, byte column) _location = (1,1);

        private static Room CurrentRoom
        {
            get
            {
                return _rooms[_location.row, _location.column];
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            InitializeRoomDescriptions();

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

        private static void InitializeRoomDescriptions()
        {
            var roomsMap = new Dictionary<string, Room>();
            foreach (Room room in _rooms)
            {
                roomsMap[room.Name] = room;
            }

            roomsMap["Rocky Trail"].Description = "You are on a rock-strewn trail.";
            roomsMap["South of House"].Description = "You are facing the south side of a white house. There is no door here, and all the windows are barred.";
            roomsMap["Canyon View"].Description = "You are at the top of the Great Canyon on its south wall.";
            roomsMap["Forest"].Description = "This is a forest, with trees in all directions around you.";
            roomsMap["West of House"].Description = "This is an open field west of a white house, with a boarded front door.";
            roomsMap["Behind House"].Description = "You are behind the white house. In one corner of the house there is a small window which is slightly ajar.";
            roomsMap["Dense Woods"].Description = "This is a dimly lit forest, with large trees all around. To the east, there appears to be sunlight.";
            roomsMap["North of House"].Description = "You are facing the north side of a white house. There is no door here, and all the windows are barred.";
            roomsMap["Clearing"].Description = "You are in a clearing, with a forest surrounding you on the west and south.";
        }
    }
}