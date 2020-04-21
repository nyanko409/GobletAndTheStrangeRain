using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [Tooltip("Simulated loading time in seconds. Set to a negative value to load immediately after loading is completed.")]
    public float simulatedLoadTime = 5;

    static GameObject loadingScreen;
    static float load = 5;


    private void Start()
    {
        loadingScreen = Resources.Load("Prefabs/UI/Loading Canvas") as GameObject;
        load = simulatedLoadTime;
    }

    public static IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        Instantiate(loadingScreen);

        if (load >= 0)
        {
            op.allowSceneActivation = false;
            yield return new WaitForSeconds(load);
            op.allowSceneActivation = true;
        }
        else
        {
            while (!op.isDone)
                yield return null;
        }
    }
}
