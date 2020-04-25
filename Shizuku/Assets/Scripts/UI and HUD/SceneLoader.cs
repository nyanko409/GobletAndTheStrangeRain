using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public abstract class SceneLoader : MonoBehaviour
{
    public static IEnumerator LoadSceneAsync(string sceneName, string prefabPath, float simulatedTime = -1)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        Instantiate(Resources.Load(prefabPath));

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
