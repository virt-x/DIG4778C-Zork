using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zork.Common;

public class UnityOutputService : MonoBehaviour, IOutputService
{
    private List<GameObject> _entries = new List<GameObject>();
    [SerializeField] private TextMeshProUGUI _textLinePrefab;
    [SerializeField] private Transform _contentTransform;
    [SerializeField] private int _maxEntries;
    public void Write(object obj)
    {
        ParseAndWriteLine(obj.ToString());
    }

    public void Write(string message)
    {
        ParseAndWriteLine(message);
    }

    public void WriteLine(object obj)
    {
        ParseAndWriteLine(obj.ToString());
    }

    public void WriteLine(string message)
    {
        ParseAndWriteLine(message);
    }

    private void ParseAndWriteLine(string message)
    {
        var textLine = Instantiate(_textLinePrefab, _contentTransform);
        textLine.text = message;
        AddEntry(textLine.gameObject);

        if (textLine.text != null && textLine.text.Contains("\n"))
        {
            string[] lines = textLine.text.Split("\n");
            textLine.text = lines[0];
            for (int i = 1; i < lines.Length; i++)
            {
                ParseAndWriteLine(lines[i]);
            }
        }

        textLine.ForceMeshUpdate();
        if (textLine.isTextOverflowing)
        {
            string overflow = textLine.text.Substring(textLine.firstOverflowCharacterIndex);
            textLine.text = textLine.text.Remove(textLine.firstOverflowCharacterIndex);
            ParseAndWriteLine(overflow);
        }
    }

    private void AddEntry(GameObject newEntry)
    {
        _entries.Add(newEntry);
        if (_entries.Count > _maxEntries)
        {
            GameObject oldLine = _entries[0];
            _entries.Remove(oldLine);
            Destroy(oldLine);
        }
    }
}
