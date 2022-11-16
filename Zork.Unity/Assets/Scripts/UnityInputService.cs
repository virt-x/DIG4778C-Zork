using System;
using UnityEngine;
using Zork.Common;

public class UnityInputService : MonoBehaviour, IInputService
{
    public event EventHandler<string> InputReceived;

    public void ProcessInput(string inputString)
    {
        if (inputString == "" || inputString == null)
        {
            return;
        }
        InputReceived?.Invoke(this, inputString);
    }
}
