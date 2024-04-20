using System;
using UnityEngine;
using UnityEngine.UI;

namespace TopDos.UI
{
    public class GameOverPresenter : MonoBehaviour
    {
        [SerializeField] private Canvas _gameOverCanvas;
        [SerializeField] private Button _retryButton;
        [SerializeField] private Button _menuButton;
        private GameMachine _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameMachine>();
            _gameManager.OnGameOver += ShowGameOver;
            _retryButton.onClick.AddListener(LoadSceneManager.Retry);
            _menuButton.onClick.AddListener(LoadSceneManager.LoadMenu);
        }

        private void ShowGameOver()
        {
            _gameOverCanvas.gameObject.SetActive(true);
        }
    }
}
