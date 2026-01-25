using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<GameState> OnGameStateChanged;

    [Header("References")]
    [SerializeField] private EggCounterUI _eggCounterUI;

    [Header("Settings")]
    [SerializeField] private int _maxEggCount = 5;

    private GameState _currentGameState;

    private int _currentEggCount;

    private void Awake()
    {
        Instance = this;
    }
    
    private void OnEnable()
    {
        ChangedGameState(GameState.Play);
    }

    public void ChangedGameState(GameState gameState)
    {
        OnGameStateChanged?.Invoke(gameState);
        _currentGameState = gameState;
        Debug.Log("Game State: " + gameState);
    }

    public void OnEggCollected()
    {
        _currentEggCount++;
        _eggCounterUI.SetEggCounterText(_currentEggCount, _maxEggCount);

        if (_currentEggCount == _maxEggCount)
        {
            //WIN
            Debug.Log("Game Win!");
            _eggCounterUI.SetEggCompleted();
            ChangedGameState(GameState.GameOver);
        }
        Debug.Log($"Eggs Collected: {_currentEggCount}/{_maxEggCount}");
    }

    public GameState GetCurrentGameState()
    {
        return _currentGameState;
    } 
}
