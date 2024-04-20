using UnityEngine;

public static class LoadSceneManager
{
    public static void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int)SceneIndexes.MENU);
    }

    public static void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int)SceneIndexes.LOADING);
    }
}
