using System;
using TopDos.Enemies;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int CurrentScore { get; private set; }
    private GameMachine _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameMachine>();
        _gameManager.OnEnemyKilled += AddScore;
    }

    private void AddScore(Enemy enemy)
    {
        CurrentScore++;
    }
}
