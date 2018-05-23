using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Playing, GameOver }

    private int _score = 0;
    private int _coin = 0;
    private GameState _currentState;

    void Start()
    {
        _score = 0;
        _coin = 0;
        _currentState = GameState.Playing;
    }

    void Update()
    {
        if (_currentState == GameState.Playing)
        {
            _score++;
        }
    }

    public void CollectCoin()
    {
        _coin++;
    }

    public void GameOver()
    {
        _currentState = GameState.GameOver;
    }

    public GameState GetGameState()
    {
        return _currentState;
    }
}
