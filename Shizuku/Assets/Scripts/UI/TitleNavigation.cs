using UnityEngine;

public class TitleNavigation : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(SceneLoader.LoadSceneAsync("StageSelect", "Prefabs/UI/Loading Canvas", 3));
    }
}
