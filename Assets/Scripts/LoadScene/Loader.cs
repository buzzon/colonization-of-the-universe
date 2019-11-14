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
        SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Additive);
    }
}
