using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Posenext : MonoBehaviour
{

    public PauseSelect data;
    public Image con;
    public Image res;
    public Image theck;
    public Image map;
    public Image back;
    public float colorspeed = 0.05f;

    GameInput actions;
    CheckPointManager checkPointManager;
    float time = 0; 
    bool confirmPressed = false;
    float CL_A = 0;
    float count = 0;
    
    int colorcount = 2;
    int poseR = 0;

    bool Restart = false;
    bool checkpoint = false;


    public int PoseRCK()
    {
        return poseR;
    }

    public bool RestartCK()
    {
        return Restart;
    }

    public bool CheckpointCK()
    {
        return checkpoint;
    }


    private void Awake()
    {
        actions = new GameInput();

        actions.UIPauseMenu.Confirm.started += context => confirmPressed = true;
        actions.UIPauseMenu.Confirm.canceled += context => confirmPressed = false;
    }

    void Start()
    {
        checkPointManager = GameObject.FindGameObjectWithTag("CheckPointManager").GetComponent<CheckPointManager>();

        con.color = new Color32(0,0,0,255);
        res.color = new Color32(0, 0, 0, 255);
        theck.color = new Color32(0, 0, 0, 255);
        map.color = new Color32(0, 0, 0, 255);
    }


    void Update()
    {
        CL_A = Mathf.Lerp(255, 0, data.CL());

        back.color = new Color32(0, 255, 0, (byte)CL_A);
        con.color = new Color32(0, 0, 0, 255);
        res.color = new Color32(0, 0, 0, 255);
        theck.color = new Color32(0, 0, 0, 255);
        map.color = new Color32(0, 0, 0, 255);

        switch (data.nextCK())
            {
                case 1:
              
                if (confirmPressed && data.BCK() == true)
                {
                    Time.timeScale = 1;
                    poseR = 1;
                }
                break;
                case 2:
                
                if (confirmPressed && data.BCK() == true)
                {
                    StartCoroutine(SceneLoader.LoadSceneAsync(SceneManager.GetActiveScene().name, "Prefabs/UI and HUD/Loading Canvas"));

                    Time.timeScale = 1;
                    poseR = 1;
                    Restart = true;
                }

                    break;
                case 3:
                   
                if (confirmPressed && data.BCK() == true)
                {
                    // reset the save point and reload the scene
                    checkPointManager.ResetSavePoint();
                    StartCoroutine(SceneLoader.LoadSceneAsync(SceneManager.GetActiveScene().name, "Prefabs/UI and HUD/Loading Canvas"));

                    Time.timeScale = 1;
                    poseR = 1;
                    checkpoint = true;
                }
                break;
                case 4:
                   

                    if (confirmPressed && data.BCK() == true)
                    {
                        Time.timeScale = 1;
                        StartCoroutine(SceneLoader.LoadSceneAsync("StageSelect", "Prefabs/UI and HUD/Loading Canvas"));
                    }
                    break;
            }
            if (data.poseED() == true)
            {
                poseR = 0;
                Restart = false;
               // Debug.Log(Restart);
            }
            if (data.poseED() == true)
            {
                poseR = 0;
                checkpoint = false;
               // Debug.Log(checkpoint);
            }
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
