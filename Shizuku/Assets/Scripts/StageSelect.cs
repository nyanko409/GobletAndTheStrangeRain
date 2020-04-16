using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    public Text stageText;
    public Sprite spriteLocked, spriteOutline;
    public Color colorLocked, colorOutline;
    [Space]
    public Stage[] stages;
    public GameObject[] stageObjects;

    GameInput action;
    int curStageIndex, oldStageIndex;
    SpriteRenderer[] rend;
    Transform camPos;


    private void Awake()
    {
        // init listeners
        action = new GameInput();

        action.UI.ConfirmStage.performed += context => LoadStage();

        action.UI.StageSelectLeft.performed += context =>
        {
            // check if stage is locked
            if (curStageIndex - 1 < 0 && stages[stages.Length - 1].isLocked)
            {
                oldStageIndex = curStageIndex;

                for(int i = stages.Length - 1; i >= 0; --i)
                {
                    if(!stages[i].isLocked)
                    {
                        curStageIndex = i;
                        break;
                    }
                }

                DisplayNextStage();
                return;
            }

            // update index
            oldStageIndex = curStageIndex;
            curStageIndex--;
            curStageIndex = curStageIndex < 0 ? stages.Length - 1 : curStageIndex;

            DisplayNextStage();
        };

        action.UI.StageSelectRight.performed += context =>
        {
            // check if stage is locked
            if (curStageIndex < stages.Length - 1 && stages[curStageIndex + 1].isLocked)
            {
                // select the first stage if locked
                oldStageIndex = curStageIndex;
                curStageIndex = 0;
                DisplayNextStage();
                return;
            }

            // update index
            oldStageIndex = curStageIndex;
            curStageIndex++;
            curStageIndex = curStageIndex >= stages.Length ? 0 : curStageIndex;

            DisplayNextStage();
        };
    }

    private void Start()
    {
        // init sprite renderers
        rend = new SpriteRenderer[stageObjects.Length];
        for(int i = 0; i < stageObjects.Length; ++i)
        {
            rend[i] = stageObjects[i].GetComponent<SpriteRenderer>();

            rend[i].enabled = stages[i].isLocked;
            if (stages[i].isLocked)
            {
                rend[i].sprite = spriteLocked;
                rend[i].color = colorLocked;
            }
            else
            {
                rend[i].sprite = spriteOutline;
                rend[i].color = colorOutline;
            }
        }

        curStageIndex = oldStageIndex = 0;
        camPos = Camera.main.transform;

        DisplayNextStage();
    }

    private void DisplayNextStage()
    {
        stageText.text = stages[curStageIndex].stageName;

        rend[oldStageIndex].enabled = false;
        rend[curStageIndex].enabled = true;
    }

    private void Update()
    {
        // zoom to stage position
        camPos.position = Vector3.Lerp(camPos.position, stageObjects[curStageIndex].transform.GetChild(0).position, 0.1F);
    }

    private void LoadStage()
    {
        SceneManager.LoadScene(stages[curStageIndex].sceneName);
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
}
