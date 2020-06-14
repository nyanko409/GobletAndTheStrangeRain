using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    static bool cleared = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            GameData data = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameData>();

            if (cleared)
            {
                FadeManager.FadeOut("Title");
            }
            else
                FadeManager.FadeOut("StageSelect");

            // unlock the next stage
            foreach(Stage stage in data.stageData)
            {
                if (stage.sceneName == SceneManager.GetActiveScene().name)
                {
                    data.UnlockStage(stage.stage + 1);
                    if (stage.stage == 8)
                        cleared = true;
                    else
                        cleared = false;

                    print(stage.stage + 1 + "unlocked");
                    print(SceneManager.GetActiveScene().name);
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
