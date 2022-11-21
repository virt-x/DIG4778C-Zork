using System;
using UnityEngine;
using Zork.Common;

public class UnityInputService : MonoBehaviour, IInputService
{
    [SerializeField] private UnityOutputService _outputService;
    public event EventHandler<string> InputReceived;

    public void ProcessInput(string inputString)
    {
        if (inputString == "" || inputString == null)
        {
            return;
        }
        _outputService.WriteLine($"\n>{inputString}");
        InputReceived?.Invoke(this, inputString);
    }
}
