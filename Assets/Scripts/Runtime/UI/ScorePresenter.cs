using TMPro;
using TopDos.Enemies;
using UnityEngine;

namespace TopDos.UI
{
    public class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private ScoreManager _scoreManager;
        private GameMachine _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameMachine>();
            _gameManager.OnEnemyKilled += UpdateScoreText;
        }

        private void UpdateScoreText(Enemy enemy)
        {
            _scoreText.text = _scoreManager.CurrentScore.ToString();
        }
    }
}
