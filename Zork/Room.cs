using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Zork
{
    public class Room
    {
        [JsonProperty(Order = 1)]
        public string Name { get; }
        [JsonProperty(Order = 2)]
        public string Description { get; set; }
        [JsonProperty(Order = 3)]
        private Dictionary<Directions, string> NeighborNames { get; set; }

        [JsonIgnore]
        public IReadOnlyDictionary<Directions, Room> Neighbors { get; private set; }

        public Room(string name, string description = "")
        {
            Name = name;
            Description = description;
        }

        public void UpdateNeighbors(World world)
        {
            Neighbors = (from entry in NeighborNames
                         let room = world.RoomsByName.GetValueOrDefault(entry.Value)
                         where room != null
                         select (Direction: entry.Key, Room: room))
                         .ToDictionary(pair => pair.Direction, pair => pair.Room);
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
