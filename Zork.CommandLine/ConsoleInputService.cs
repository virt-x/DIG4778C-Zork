﻿using System;
using Zork.Common;

namespace Zork.CommandLine
{
    class ConsoleInputService : IInputService
    {
        public event EventHandler<string> InputReceived;

        public void ProcessInput()
        {
            string inputString = Console.ReadLine().Trim();
            InputReceived?.Invoke(this, inputString);
        }
    }
}
