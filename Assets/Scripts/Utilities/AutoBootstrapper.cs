#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoBootstrapper
{
    private const string BootstrapSceneName = "Bootstrap";
    private static bool hasRedirected = false;
    public static string sceneToLoad;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void RedirectToBootstrap()
    {
        var activeScene = SceneManager.GetActiveScene().name;
        sceneToLoad = activeScene;
        if (activeScene == BootstrapSceneName)
            return;

        if (hasRedirected)
            return;

        hasRedirected = true;

        SceneManager.LoadScene(BootstrapSceneName, LoadSceneMode.Single);
    }
}
#endif