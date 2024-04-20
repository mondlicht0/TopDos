using System;
using UnityEngine;

namespace TopDos.UI
{
    public class GameOverPresenter : MonoBehaviour
    {
        [SerializeField] private Canvas _gameOverCanvas;
        private GameMachine _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameMachine>();
            _gameManager.OnGameOver += ShowGameOver;
        }

        private void ShowGameOver()
        {
            _gameOverCanvas.gameObject.SetActive(true);
        }
    }
}
