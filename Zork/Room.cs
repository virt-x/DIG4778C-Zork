﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Zork
{
    public class Room : IEquatable<Room>
    {
        [JsonProperty(Order = 1)]
        public string Name { get; }
        [JsonProperty(Order = 2)]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "Neighbors", Order = 3)]
        private Dictionary<Directions, string> NeighborNames { get; set; }

        [JsonIgnore]
        public IReadOnlyDictionary<Directions, Room> Neighbors { get; private set; }

        public static bool operator ==(Room lhs, Room rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }

            if (lhs is null || rhs is null)
            {
                return false;
            }

            return lhs.Name == rhs.Name;
        }

        public static bool operator !=(Room lhs, Room rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            return obj is Room room ? this == room : false;
        }

        public bool Equals(Room other)
        {
            return this == other;
        }

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
