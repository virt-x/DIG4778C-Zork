using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Zork.Common
{
    public class Room : IEquatable<Room>
    {
        private List<Item> _inventory;
        [JsonProperty(Order = 1)]
        public string Name { get; }
        [JsonProperty(Order = 2)]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "Neighbors", Order = 3)]
        private Dictionary<Directions, string> NeighborNames { get; set; }
        [JsonProperty(PropertyName = "Items", Order = 4)]
        public List<string> InventoryNames { get; private set; }

        [JsonIgnore]
        public IReadOnlyDictionary<Directions, Room> Neighbors { get; private set; }
        [JsonIgnore]
        public IReadOnlyList<Item> Inventory => _inventory;

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
            return obj is Room room && this == room;
        }

        public bool Equals(Room other)
        {
            return this == other;
        }

        public Room(string name, string description, Dictionary<Directions, string> neighbors, List<string> items)
        {
            Name = name;
            Description = description;
            NeighborNames = neighbors ?? new Dictionary<Directions, string>();
            InventoryNames = items ?? new List<string>();
        }

        public void UpdateNeighbors(World world)
        {
            Neighbors = (from entry in NeighborNames
                         let room = world.RoomsByName.GetValueOrDefault(entry.Value)
                         where room != null
                         select (Direction: entry.Key, Room: room))
                         .ToDictionary(pair => pair.Direction, pair => pair.Room);

            NeighborNames = null;
        }

        public void UpdateInventory(World world)
        {
            _inventory = (from entry in InventoryNames
                         let item = world.ItemsByName.GetValueOrDefault(entry.ToUpper())
                         where item != null
                         select item).ToList();

            InventoryNames = null;
        }

        public void AddItem(Item item)
        {
            _inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (Inventory.Contains(item))
            {
                _inventory.Remove(item);
            }
            else
            {
                throw new Exception($"Item {item.Name} does not exist in this room.");
            }
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
