using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Zork.Common
{
    public class Player
    {
        private World _world;
        private int _moves;
        private int _score;
        private Room _location;
        private List<Item> _inventory;
        public event EventHandler<int> MovesChanged;
        public event EventHandler<int> ScoreChanged;
        public event EventHandler<string> LocationChanged;
        [JsonIgnore]
        public Room Location
        {
            get
            {
                return _location;
            }
            private set
            {
                _location = value;
                LocationChanged?.Invoke(this, _location?.Name);
            }
        }
        [JsonIgnore]
        public string LocationName
        {
            get
            {
                return Location?.Name;
            }
            set
            {
                Location = _world?.RoomsByName[value];
            }
        }
        [JsonIgnore]
        public int Score
        {
            get => _score;
            set
            {
                if (_score != value)
                {
                    _score = value;
                    ScoreChanged?.Invoke(this, _score);
                }
            }
        }
        [JsonIgnore]
        public int MoveCount
        {
            get => _moves;
            set
            {
                if (_moves != value)
                {
                    _moves = value;
                    MovesChanged?.Invoke(this, _moves);
                }
            }
        }
        [JsonIgnore]
        public IReadOnlyList<Item> Inventory => _inventory;

        public Player(World world, string startingLocation)
        {
            _world = world;
            LocationName = startingLocation;
            if (Location == null)
            {
                throw new Exception($"Invalid starting location: {startingLocation}");
            }
            _inventory = new List<Item>();
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

        public void AddItem(Item item)
        {
            _inventory.Add(item);
            MoveCount++;
        }

        public void RemoveItem(Item item)
        {
            _inventory.Remove(item);
            MoveCount++;
        }
    }
}
