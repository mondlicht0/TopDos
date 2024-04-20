using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TopDos.Loading
{
    public class LoadingScreen : MonoBehaviour
    {
        [Header("Slider")]
        [SerializeField] private Slider _slider;

        private void Start()
        {
            LoadLevel((int)SceneIndexes.GAMEPLAY);
        }

        public void LoadLevel(int buildIndex)
        {
            StartCoroutine(LoadLevelAsync(buildIndex));
        }

        private IEnumerator LoadLevelAsync(int buildIndex)
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(buildIndex);

            while (!loadOperation.isDone)
            {
                float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
                _slider.value = progressValue;
                yield return null;
            }
        }
    }
}
