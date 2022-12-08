using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Zork.Common
{
    public class World : INotifyPropertyChanged
    {
        public HashSet<Room> Rooms { get; set; }
        public HashSet<Item> Items { get; set; }
        [JsonIgnore]
        public IReadOnlyDictionary<string, Room> RoomsByName => _roomsByName;
        [JsonIgnore]
        public IReadOnlyDictionary<string, Item> ItemsByName => _itemsByName;

        [JsonProperty]
        public string StartingLocation { get; set; }
        private Dictionary<string, Room> _roomsByName;
        private Dictionary<string, Item> _itemsByName;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public World ()
        {
            Rooms = new HashSet<Room>();
            Items = new HashSet<Item>();
            _roomsByName = new Dictionary<string, Room>();
            _itemsByName = new Dictionary<string, Item>();
        }

        public void AddRoom(Room room)
        {
            if (!Rooms.Contains(room) && !_roomsByName.ContainsKey(room.Name))
            {
                Rooms.Add(room);
                _roomsByName.Add(room.Name, room);
            }
            else
            {
                throw new System.Exception("A room by that name already exists.");
            }
        }
        public void RemoveRoom(Room room)
        {
            if (Rooms.Contains(room) && _roomsByName.ContainsKey(room.Name))
            {
                Rooms.Remove(room);
                _roomsByName.Remove(room.Name);
            }
            else
            {
                throw new System.Exception("A room by that name does not exist.");
            }
        }
    }
}
