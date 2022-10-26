using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;

namespace Zork
{
    public class World
    {
        public HashSet<Room> Rooms { get; set; }
        public HashSet<Item> Items { get; set; }
        [JsonIgnore]
        public IReadOnlyDictionary<string, Room> RoomsByName => _roomsByName;
        [JsonIgnore]
        public IReadOnlyDictionary<string, Item> ItemsByName => _itemsByName;

        [JsonProperty]
        private string StartingLocation { get; set; }
        private Dictionary<string, Room> _roomsByName;
        private Dictionary<string, Item> _itemsByName;

        public Player SpawnPlayer()
        {
            return new Player(this, StartingLocation);
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            _roomsByName = Rooms.ToDictionary(room => room.Name, room => room);

            _itemsByName = Items.ToDictionary(item => item.Name.ToUpper(), item => item);

            foreach (Room room in Rooms)
            {
                room.UpdateNeighbors(this);
                room.UpdateInventory(this);
            }
        }

    }
}
