using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TopDos.UI
{
    public class MenuPresenter : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _playButton.onClick.AddListener(Play);
            _exitButton.onClick.AddListener(Exit);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(Play);
            _exitButton.onClick.RemoveListener(Exit);
        }

        private void Play()
        {
            SceneManager.LoadScene((int)SceneIndexes.LOADING);
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}
