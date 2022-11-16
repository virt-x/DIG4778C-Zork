using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zork.Common
{
    public class Game
    {
        public World World { get; }

        [JsonIgnore]
        public Player Player { get; private set; }

        public IOutputService Output { get; private set; }
        public IInputService Input { get; private set; }

        public Game(World world, Player player)
        {
            World = world;
            if (player != null)
            {
                Player = player;
            }
            else
            {
                Player = World.SpawnPlayer();
            };
        }

        public bool IsRunning { get; private set; }
        public Room PreviousRoom { get; private set; }

        public EventHandler<bool> QuitEvent;

        public void Run(IInputService inputService, IOutputService outputService)
        {
            Input = inputService ?? throw new ArgumentNullException(nameof(inputService));
            Output = outputService ?? throw new ArgumentNullException(nameof(outputService));
            IsRunning = true;
            Input.InputReceived += Input_InputReceived;

            Prompt();
        }

        private enum CommandArguments
        {
            Verb = 0,
            Subject
        }
        private void Input_InputReceived(object sender, string inputString)
        {
            string[] commandInputs = inputString.Split(" ");
            Commands command = ToCommand(commandInputs[(int)CommandArguments.Verb]);

            string outputString;
            var additionalOutputs = new List<string>();
            switch (command)
            {
                case Commands.QUIT:
                    outputString = "Thank you for playing!";
                    IsRunning = false;
                    break;
                case Commands.LOOK:
                    outputString = Player.Location.Description;
                    foreach (Item item in Player.Location.Inventory)
                    {
                        additionalOutputs.Add(item.Description);
                    }
                    break;
                case Commands.NORTH:
                case Commands.SOUTH:
                case Commands.EAST:
                case Commands.WEST:
                    Directions direction = (Directions)command;
                    outputString = Player.Move(direction) ? $"You moved {direction}." : "The way is shut!";
                    break;
                case Commands.SCORE:
                    outputString = $"Your score would be {Player.Score}, in {Player.MoveCount} move(s).";
                    break;
                case Commands.REWARD:
                    outputString = "Score increased.";
                    Player.Score++;
                    break;
                case Commands.TAKE:
                    switch (commandInputs.Length)
                    {
                        case 1:
                            outputString = "This command requires a subject.";
                            break;
                        default:
                            if (World.ItemsByName.TryGetValue(commandInputs[(int)CommandArguments.Subject].ToUpper(), out Item target))
                            {
                                if (Player.Inventory.Contains(target))
                                {
                                    outputString = "You already have that.";
                                }
                                else if (Player.Location.Inventory.Contains(target))
                                {
                                    outputString = "Taken.";
                                    Player.AddItem(target);
                                    Player.Location.RemoveItem(target);
                                }
                                else
                                {
                                    outputString = "You can't see any such thing.";
                                }
                            }
                            else
                            {
                                outputString = "You can't see any such thing.";
                            }
                            break;
                    }
                    break;
                case Commands.DROP:
                    switch (commandInputs.Length)
                    {
                        case 1:
                            outputString = "This command requires a subject.";
                            break;
                        default:
                            if (World.ItemsByName.TryGetValue(commandInputs[(int)CommandArguments.Subject].ToUpper(), out Item target))
                            {
                                if (Player.Location.Inventory.Contains(target))
                                {
                                    outputString = "That's already here.";
                                }
                                else if (Player.Inventory.Contains(target))
                                {
                                    outputString = "Dropped.";
                                    Player.RemoveItem(target);
                                    Player.Location.AddItem(target);
                                }
                                else
                                {
                                    outputString = "You don't have any such thing.";
                                }
                            }
                            else
                            {
                                outputString = "You don't have any such thing.";
                            }
                            break;
                    }
                    break;
                case Commands.INVENTORY:
                    if (Player.Inventory.Count > 0)
                    {
                        outputString = "Your inventory contains:";
                        foreach (Item item in Player.Inventory)
                        {
                            additionalOutputs.Add(item.HeldDescription);
                        }
                    }
                    else
                    {
                        outputString = "You are empty-handed.";
                    }
                    break;
                default:
                    outputString = "Unknown command.";
                    break;
            }

            Output.WriteLine(outputString);
            foreach (string output in additionalOutputs)
            {
                Output.WriteLine(output);
            }
            if (IsRunning)
            {
                Prompt();
            }
            else
            {
                QuitEvent?.Invoke(this, IsRunning);
            }
        }

        private void Prompt()
        {
            Output.WriteLine(null);
            Output.WriteLine(Player.Location);
            if (PreviousRoom != Player.Location)
            {
                Output.WriteLine(Player.Location.Description);
                foreach (Item item in Player.Location.Inventory)
                {
                    Output.WriteLine(item.Description);
                }
                PreviousRoom = Player.Location;
            }
        }

        public static Game Load(string content)
        {
            return JsonConvert.DeserializeObject<Game>(content);
        }

        private static Commands ToCommand(string commandString)
        {
            return Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        }
    }
}
