using UnityEngine.SceneManagement;
using UnityEngine;

public static class Loader
{
    public enum SceneType
    {
        GlobalMap,
        Sector
    }

    public static void Load(SceneType sceneType)
    {
        SceneManager.LoadScene(sceneType.ToString(), LoadSceneMode.Additive);
    }

    [System.Obsolete]
    public static void UnLoad(SceneType sceneType)
    {
        if (SceneManager.sceneCount <= 1)
            return;
        SceneManager.UnloadScene(sceneType.ToString());
    }
}
