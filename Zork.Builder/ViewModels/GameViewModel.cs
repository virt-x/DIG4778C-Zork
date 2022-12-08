using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Zork.Common;
using Newtonsoft.Json;
using System.IO;

namespace Zork.Builder.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private Game _game;
        public string Filename { get; set; }
        public Game Game
        {
            set
            {
                if (_game != value)
                {
                    _game = value;
                    if (_game != null)
                    {
                        Rooms = new BindingList<Room>(_game.World.Rooms.ToList());
                        Items = new BindingList<Item>(_game.World.Items.ToList());
                        StartingLocation = _game.World.StartingLocation;
                    }
                    else
                    {
                        Rooms = new BindingList<Room>();
                        Items = new BindingList<Item>();
                        StartingLocation = "New Room";
                    }
                }
            }
        }
        public BindingList<Room> Rooms { get; set; }
        public BindingList<Item> Items { get; set; }
        public string StartingLocation { get; set; }

        public GameViewModel()
        {
            Filename = "New";
            World world = new World();
            Room room = new Room("New Room", "Description", new Dictionary<Directions, string>(), new List<string>());
            world.AddRoom(room);
            world.StartingLocation = room.Name;
            Game = new Game(world, world.SpawnPlayer());
        }

        public void Save()
        {
            _game.World.Rooms = new HashSet<Room>(Rooms);
            _game.World.Items = new HashSet<Item>(Items);
            _game.World.StartingLocation = StartingLocation;



            JsonSerializer serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented
            };
            using (StreamWriter streamWriter = new StreamWriter(Filename))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, _game);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
