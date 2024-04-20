using System;
using TopDos.Enemies;
using TopDos.PlayerSpace;
using UnityEngine;
using Zenject;

public enum GameState
{
    OFF = 0,
    PLAY = 1,
    PAUSE = 2,
    FINISH = 3,
}

public class GameMachine : MonoBehaviour
{
    private PlayerHealth _healthController;
    public GameState GameState { get; private set; } = GameState.OFF;
    public event Action<Enemy> OnEnemyKilled;

    public event Action OnGameStart;
    public event Action OnGamePause;
    public event Action OnGameOver;
    public event Action OnGameOff;
    public event Action OnGameResume;
    
    

    [Inject]
    private void Construct(PlayerHealth health)
    {
        _healthController = health;
    }
    
    private void Start()
    {
        _healthController.OnDied += FinishGame;
        GameState = GameState.PLAY;
    }
    
    public void SendEnemyKilled(Enemy enemy)
    {
        OnEnemyKilled?.Invoke(enemy);
    }

    public void StartGame()
    {
        if (GameState != GameState.OFF)
        {
            return;
        }

        GameState = GameState.PLAY;
        OnGameStart?.Invoke();
    }
    
    public void PauseGame()
    {
        if (GameState != GameState.PLAY)
        {
            return;
        }
        
        GameState = GameState.PAUSE;
        OnGamePause?.Invoke();
    }

    public void ResumeGame()
    {
        if (GameState != GameState.PAUSE)
        {
            return;
        }

        GameState = GameState.PLAY;
        OnGameResume?.Invoke();
    }

    public void FinishGame()
    {
        if (GameState != GameState.PLAY)
        {
            return;
        }

        GameState = GameState.FINISH;
        OnGameOver?.Invoke();
        
    }
}
