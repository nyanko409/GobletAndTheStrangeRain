using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            FadeManager.FadeOut("StageSelect");

            // unlock the next stage
            GameData data = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameData>();
            foreach(Stage stage in data.stageData)
            {
                if (stage.sceneName == SceneManager.GetActiveScene().name)
                {
                    data.UnlockStage(stage.stage + 1);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn();
    }
}
