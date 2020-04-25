using UnityEngine;

public class TitleNavigation : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(SceneLoader.LoadSceneAsync("StageSelect", "Prefabs/UI and HUD/Loading Canvas", 3));
    }
}
