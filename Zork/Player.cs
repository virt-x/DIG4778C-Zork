using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Zork
{
    public class Player
    {
        private World _world;
        [JsonIgnore]
        public Room Location { get; private set; }
        [JsonIgnore]
        public string LocationName
        {
            get
            {
                return Location?.Name;
            }
            set
            {
                Location = _world?.RoomsByName.GetValueOrDefault(value);
            }
        }
        [JsonIgnore]
        public int Score { get; set; }
        [JsonIgnore]
        public int MoveCount { get; private set; }
        [JsonIgnore]
        public List<Item> Inventory { get; }

        public Player(World world, string startingLocation)
        {
            _world = world;
            LocationName = startingLocation;
            if (Location == null)
            {
                throw new Exception($"Invalid starting location: {startingLocation}");
            }
        }

        public bool Move(Directions direction)
        {
            bool isValidMove = Location.Neighbors.TryGetValue(direction, out Room destination);
            if (isValidMove)
            {
                Location = destination;
                MoveCount++;
            }
            return isValidMove;
        }
    }
}
