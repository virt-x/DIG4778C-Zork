using TMPro;
using UnityEngine;
using Zork.Common;

public class GameManager : MonoBehaviour
{
    private Game _game;
    [SerializeField] private UnityInputService _input;
    [SerializeField] private UnityOutputService _output;
    [SerializeField] private TextMeshProUGUI _locationLabel;
    [SerializeField] private TextMeshProUGUI _scoreLabel;
    [SerializeField] private TextMeshProUGUI _movesLabel;
    public UnityInputService Input { get => _input; }

    private void Awake()
    {
        TextAsset gameJson = Resources.Load<TextAsset>("GameJson");
        _game = Game.Load(gameJson.text);
        _game.Run(_input, _output);
        _game.Player.LocationChanged += UpdateLocation;
        _game.Player.ScoreChanged += UpdateScore;
        _game.Player.MovesChanged += UpdateMoves;
        _game.QuitEvent += Quit;

        UpdateLocation(this, _game.Player.LocationName);
        UpdateScore(this, _game.Player.Score);
        UpdateMoves(this, _game.Player.MoveCount);
    }

    private void UpdateLocation(object sender, string location)
    {
        _locationLabel.text = location;
    }

    private void UpdateScore(object sender, int value)
    {
        _scoreLabel.text = $"Score: {value}";
    }

    private void UpdateMoves(object sender, int value)
    {
        _movesLabel.text = $"Moves: {value}";
    }

    private void Quit(object sender, bool isRunning)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}