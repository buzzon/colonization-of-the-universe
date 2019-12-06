using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        GlobalScene,
        Sector
    }

    public static void Load(Scene scene)
    {
        if (SceneManager.sceneCount >= 2) return;
        SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Additive);
    }

    [System.Obsolete]
    public static void UnLoad(Scene scene)
    {
        if (SceneManager.sceneCount <= 1) return;
        SceneManager.UnloadScene(scene.ToString());
    }

}
