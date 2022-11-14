using TMPro;
using UnityEngine;
using Zork.Common;

public class UnityOutputService : MonoBehaviour, IOutputService
{
    public TextMeshProUGUI testLine;
    public void Write(object obj)
    {
    }

    public void Write(string message)
    {
        testLine.text = message;
    }

    public void WriteLine(object obj)
    {
    }

    public void WriteLine(string message)
    {
        testLine.text = message;
    }
}
