using UnityEngine;
using UnityEngine.UI;

public class PauseSelect : MonoBehaviour
{

    public Posenext Posenext;
    public Image CLdata;
    public RectTransform data;
    public GameObject pose;
    public GameObject restart;
    public GameObject check;
    public GameObject remap;

    GameInput actions;
    //bool check = false;
    bool Bcheck = false;
    bool poseend = false;

    float nowW = 0;
    float nowH = 0;
    int Wmax = 770;
    int Hmax = 470;
    int nextselect = 1;
    float SZcount = 0;
    public float countSpeed = 0.05f;
    
    bool pausePressed = false;
    bool upPressed = false, downPressed = false;


    private void Awake()
    {
        actions = new GameInput();

        actions.UIPauseMenu.TogglePauseMenu.started += context => pausePressed = true;
        actions.UIPauseMenu.TogglePauseMenu.canceled += context => pausePressed = false;

        actions.UIPauseMenu.NavigateUp.started += context => upPressed = true;
        actions.UIPauseMenu.NavigateUp.canceled += context => upPressed = false;
        actions.UIPauseMenu.NavigateDown.started += context => downPressed = true;
        actions.UIPauseMenu.NavigateDown.canceled += context => downPressed = false;
    }


    public bool poseED()
    {
        return poseend;
    }
    public bool BCK()
    {
        return Bcheck;
    }

    public int nextCK()
    {
        return nextselect;
    }

    private void Active(bool x)
    {
        pose.SetActive(x);
        restart.SetActive(x);
        check.SetActive(x);
        remap.SetActive(x);
    }

    void Start()
    {
        pose.SetActive(false);
        restart.SetActive(false);
        check.SetActive(false);
        remap.SetActive(false);
        //main.SetActive(false);
        data = GetComponent<RectTransform>();
        data.sizeDelta = new Vector2(0, 0);
        data.anchoredPosition = new Vector2(0,0);
    }


    void Update()
    {
        data.sizeDelta = new Vector2(nowW, nowH);
        nowW = Mathf.Lerp(0, Wmax, SZcount);
        nowH = Mathf.Lerp(0, Hmax, SZcount);

        if (pausePressed /*&&check==false*/)
        {
            pausePressed = false;
            Bcheck = !Bcheck;
            Time.timeScale = Bcheck ? 0 : 1;
            Debug.Log(check);
        }

        if (Bcheck == true)
        {
            poseend = false;
            // main.SetActive(true);
            if (SZcount < 1)
            {
                SZcount += countSpeed;
                // Debug.Log(SZcount);
            }
            else
            {
                Active(true);
            }
        }
        else if (Bcheck == false)
        {
            poseend = true;
            Active(false);
           
            if (SZcount > 0)
            {
                SZcount -= countSpeed;

            }
        }

        switch(Posenext.PoseRCK())
        {
           

            case 1:
                Bcheck = false;
                poseend = true;
             
                break;

        }
       
        if (downPressed && nextselect==1&& Bcheck == true)
        {
            downPressed = false;
            nextselect = 2;
            
        }

        if(downPressed && nextselect==2 && Bcheck == true)
        {
            downPressed = false;
            nextselect = 3;
            
        }

        if (downPressed && nextselect == 3 && Bcheck == true)
        {
            downPressed = false;
            nextselect = 1;
            
        }

        if (upPressed && nextselect == 1 && Bcheck == true)
        {
            upPressed = false;
            nextselect = 3;
            
        }

        if (upPressed && nextselect == 3 && Bcheck == true)
        {
            upPressed = false;
            nextselect = 2;           
        }

        if (upPressed && nextselect == 2 && Bcheck == true)
        {
            upPressed = false;
            nextselect = 1;
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
