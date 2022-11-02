﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Zork.Common
{
    public class Player
    {
        private World _world;
        private int _moves;
        private int _score;
        public event EventHandler<int> MovesChanged;
        public event EventHandler<int> ScoreChanged;
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
        public List<Item> Inventory { get; }

        public Player(World world, string startingLocation)
        {
            _world = world;
            LocationName = startingLocation;
            if (Location == null)
            {
                throw new Exception($"Invalid starting location: {startingLocation}");
            }
            Inventory = new List<Item>();
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
            Inventory.Add(item);
            MoveCount++;
        }

        public void RemoveItem(Item item)
        {
            Inventory.Remove(item);
            MoveCount++;
        }
    }
}