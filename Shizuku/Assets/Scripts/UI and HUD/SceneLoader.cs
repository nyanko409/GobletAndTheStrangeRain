using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public abstract class SceneLoader : MonoBehaviour
{
    private static bool isLoading = false;


    public static IEnumerator LoadSceneAsync(string sceneName, string prefabPath, float simulatedTime = -1)
    {
        // prevent loading the scene multiple times by mashing the button
        if (!isLoading)
        {
            isLoading = true;

            // load the scene in the background
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
            Instantiate(Resources.Load(prefabPath));

            // switch scene if the scene is finished loading
            if (simulatedTime >= 0)
            {
                op.allowSceneActivation = false;
                yield return new WaitForSeconds(simulatedTime);
                op.allowSceneActivation = true;
            }
            else
            {
                while (!op.isDone)
                    yield return null;
            }

            isLoading = false;
        }
    }
}
