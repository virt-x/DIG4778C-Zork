using System;
using UnityEngine;
using Zork.Common;

public class UnityInputService : MonoBehaviour, IInputService
{
    public event EventHandler<string> InputReceived;

    public void ProcessInput(string inputString)
    {
        InputReceived?.Invoke(this, inputString);
    }
}
