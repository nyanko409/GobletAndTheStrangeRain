using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    public Image infoImage;
    public Color unlockedColor, lockedColor, selectedColor;
    [Space]
    public Stage[] stages;
    public GameObject[] stageObjects;
    public Sprite[] stageInfoImages;

    static int curStageIndex = 0, oldStageIndex = 0;
    GameInput action;
    SpriteRenderer[] rend;
    Transform camPos;
    bool stickSelect = false;


    private void Awake()
    {
        // init listeners
        action = new GameInput();

        action.UIStageSelect.ConfirmStage.performed += context => LoadStage();

        action.UIStageSelect.ReturnToTitle.performed += context => LoadTitle();

        action.UIStageSelect.StageSelectLeft.performed += context =>
        {
            SelectLeft();
        };

        action.UIStageSelect.StageSelectRight.performed += context =>
        {
            SelectRight();
        };

        action.UIStageSelect.StageSelectStick.performed += context =>
        {
            var value = context.ReadValue<float>();

            if (stickSelect && Mathf.Abs(value) < 0.5F)
                stickSelect = false;

            if (stickSelect)
                return;

            if (value > 0.5F)
            {
                SelectRight();
                stickSelect = true;
            }
            else if (value < -0.5F)
            {
                SelectLeft();
                stickSelect = true;
            }
        };
    }

    private void SelectLeft()
    {
        // check if stage is locked
        if (curStageIndex - 1 < 0 && stages[stages.Length - 1].isLocked)
        {
            oldStageIndex = curStageIndex;

            for (int i = stages.Length - 1; i >= 0; --i)
            {
                if (!stages[i].isLocked)
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
    }

    private void SelectRight()
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
                rend[i].color = lockedColor;
            }
            else
            {
                rend[i].color = unlockedColor;
            }
        }

        if(stages[1].isLocked)
            curStageIndex = oldStageIndex = 0;

        camPos = Camera.main.transform;
        camPos.position = stageObjects[curStageIndex].transform.GetChild(0).position;

        DisplayNextStage();
    }

    private void DisplayNextStage()
    {
        infoImage.sprite = stageInfoImages[curStageIndex];

        rend[oldStageIndex].enabled = false;
        rend[curStageIndex].enabled = true;
        rend[curStageIndex].color = selectedColor;
    }

    private void Update()
    {
        // zoom to stage position
        camPos.position = Vector3.Lerp(camPos.position, stageObjects[curStageIndex].transform.GetChild(0).position, 0.1F);
    }

    private void LoadStage()
    {
        // load the selected stage
        if (stages[curStageIndex].sceneName.Length > 0)
        {
           StartCoroutine(SceneLoader.LoadSceneAsync(stages[curStageIndex].sceneName, "Prefabs/UI and HUD/Loading Canvas", 3));
        }
    }

    private void LoadTitle()
    {
        StartCoroutine(SceneLoader.LoadSceneAsync("Title", "Prefabs/UI and HUD/Loading Canvas"));
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
