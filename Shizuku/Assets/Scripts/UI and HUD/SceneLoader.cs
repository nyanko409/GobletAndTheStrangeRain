using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static IEnumerator LoadSceneAsync(string sceneName, string prefabPath, float simulatedTime = -1)
    {
        // switch to an empty scene
        SceneManager.LoadScene("LoadingScreen");

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
    }
}
