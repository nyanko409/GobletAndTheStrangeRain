using UnityEngine;
using UnityEngine.UI;

public class NotTCPauseslect : MonoBehaviour
{

    public NotTK Posenext;
    public Image CLdata;
    public RectTransform data;
    public GameObject pose;
    public GameObject Continue;
   // public GameObject restart;
    public GameObject check;
    public GameObject remap;
    public GameObject back;
    public float colorspeed = 0.1f;

    GameInput actions;
    //bool check = false;
    bool Bcheck = false;
    bool poseend = false;

    float time = 0;
    float nowW = 0;
    float nowH = 0;
    float count = 0;
    int Wmax = 770;
    int Hmax = 470;
    int nextselect = 1;
    int colorcount = 2;
    float SZcount = 0;
    public float countSpeed = 0.05f;

    float size;
    int BSTcount;
    float Bcount = 0;
    float Bcountspeed = 0.2f;
    float Bpos = 0;
    float Bposnext;
    float Bsizenext;
    float Bpospast;
    float Bsizepast;
    bool BCcheck = false;

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


    public float BposCK()
    {
        return Bposnext;
    }
    public float BsizeCK()
    {
        return Bsizenext;
    }
    public float CL()
    {
        return count;
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
        Continue.SetActive(x);
       // restart.SetActive(x);
        check.SetActive(x);
        remap.SetActive(x);
        back.SetActive(x);
    }

    void Start()
    {
        Active(false);
        //main.SetActive(false);
        data = GetComponent<RectTransform>();
        data.sizeDelta = new Vector2(0, 0);
        data.anchoredPosition = new Vector2(0, 0);
    }


    void Update()
    {
        // Debug.Log(Time.fixedDeltaTime);
        time += 0.016f;
        if (time >= 0.01f)
        {


            data.sizeDelta = new Vector2(nowW, nowH);
            nowW = Mathf.Lerp(0, Wmax, SZcount);
            nowH = Mathf.Lerp(0, Hmax, SZcount);
            Bpos = Mathf.Lerp(Bpospast, Bposnext, Bcount);
            size = Mathf.Lerp(Bsizepast, Bsizenext, Bcount);

            if (pausePressed /*&&check==false*/)
            {
                pausePressed = false;
                Bcheck = !Bcheck;
                Time.timeScale = Bcheck ? 0 : 1;
                // Debug.Log(check);
            }

            if (Bcheck == true)
            {
                switch (colorcount)
                {
                    case 1:
                        count += colorspeed;
                        if (count >= 1)
                        {
                            colorcount = 2;
                        }
                        break;
                    case 2:
                        count -= colorspeed;
                        if (count <= 0)
                        {
                            colorcount = 1;
                        }
                        break;
                }
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

            switch (Posenext.PoseRCK())
            {


                case 1:
                    Bcheck = false;
                    poseend = true;

                    break;

            }

            if (downPressed && nextselect == 1 && Bcheck == true)
            {
                downPressed = false;
                nextselect = 2;


            }

            if (downPressed && nextselect == 2 && Bcheck == true)
            {
                downPressed = false;
                nextselect = 3;

            }

            if (downPressed && nextselect == 3 && Bcheck == true)
            {
                downPressed = false;
                nextselect = 1;

            }
            //if (downPressed && nextselect == 4 && Bcheck == true)
            //{
            //    downPressed = false;
            //    nextselect = 1;

            //}

            if (upPressed && nextselect == 1 && Bcheck == true)
            {
                upPressed = false;
                nextselect = 3;

            }
            if (upPressed && nextselect == 2 && Bcheck == true)
            {
                upPressed = false;
                nextselect = 1;

            }
            if (upPressed && nextselect == 3 && Bcheck == true)
            {
                upPressed = false;
                nextselect = 2;

            }
            //if (upPressed && nextselect == 4 && Bcheck == true)
            //{
            //    upPressed = false;
            //    nextselect = 3;


            //}
            // Debug.Log(Bcount);
            switch (BSTcount)
            {
                case 1:
                    Bcount += Bcountspeed;
                    if (Bcount >= 1)
                    {
                        BSTcount = 2;
                    }
                    break;
                case 2:
                    BCcheck = false;
                    break;
            }
            switch (nextselect)
            {
                case 1:
                    if (!BCcheck)
                    {
                        Bcount = 0;
                        BSTcount = 1;
                        BCcheck = true;
                        Bpospast = Bpos;
                        Bposnext = 67;
                        Bsizepast = size;
                        Bsizenext = 200;
                    }
                    break;
                case 2:
                    if (!BCcheck)
                    {
                        Bcount = 0;
                        BSTcount = 1;
                        BCcheck = true;
                        Bpospast = Bpos;
                        Bposnext = -40;
                        Bsizepast = size;
                        Bsizenext = 500;
                    }
                    break;
                case 3:
                    if (!BCcheck)
                    {
                        Bcount = 0;
                        BSTcount = 1;
                        BCcheck = true;
                        Bpospast = Bpos;
                        Bposnext = -148;
                        Bsizepast = size;
                        Bsizenext = 400;
                    }
                    break;
                //case 4:
                //    if (!BCcheck)
                //    {
                //        Bcount = 0;
                //        BSTcount = 1;
                //        BCcheck = true;
                //        Bpospast = Bpos;
                //        Bposnext = -195;
                //        Bsizepast = size;
                //        Bsizenext = 400;
                //    }
                //    break;
            }
            time = 0;
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
