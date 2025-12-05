using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeManager : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> initializerScripts = new List<MonoBehaviour>();

#if UNITY_EDITOR
    private string nextSceneName;
#else
    private string nextSceneName = "MainMenu";
#endif

    private void Start()
    {
#if UNITY_EDITOR
        nextSceneName = AutoBootstrapper.sceneToLoad;
#endif
        StartCoroutine(WaitForInitializers());
    }

    private IEnumerator WaitForInitializers()
    {
        yield return null;

        var initializers = initializerScripts.OfType<IInitializer>().ToList();

        DebugHandler.Log($"[InitializeManager] Found {initializers.Count} initializers.");

        while (!initializers.All(i => i.IsInitialized))
            yield return null;

        DebugHandler.Log("[InitializeManager] All systems initialized.");

        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}