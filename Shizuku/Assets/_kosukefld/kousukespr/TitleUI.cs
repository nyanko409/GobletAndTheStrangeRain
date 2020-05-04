using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    

    public PushAUI aui;

    public Image Title;
    public GameObject starttext;
    public GameObject button;
    public GameObject button2;
    public GameObject button3;

    private RectTransform data;

    Color color;
    Color color2;

    int CL_MAX = 255;
    int sizemaxW = 100;
    int sizemaxH = 110;
    int nextselect = 1;
    public  float posxmin = -573;
    public float posymin = 289;
    float poscount = 0;
    float sizenowW = 0;
    float sizenowH = 0;
    float CL_now = 0;
    float sizecount = 0;
    float colorcount = 0;
    float nextsizex = 0;
    float nextsizey = 62;

    bool nextST = false;
    bool action = false;
    bool textcheck = false;
    bool buttoncheck = false;
    bool stratcheck = true;

    private GameInput actions;
    bool upPressed = false, downPressed = false;
    bool startPressed = false;


    private void Awake()
    {
        actions = new GameInput();

        actions.UITitle.PressToStart.started += context => { startPressed = true; };
        actions.UITitle.PressToStart.canceled += context => { startPressed = false; };

        actions.UITitle.NavigateUp.started += context => { upPressed = true; };
        actions.UITitle.NavigateUp.canceled += context => { upPressed = false; };
        actions.UITitle.NavigateDown.started += context => { downPressed = true; };
        actions.UITitle.NavigateDown.canceled += context => { downPressed = false; };
    }

    public bool Titletest()
    {
        return action;
    }

    public bool BuuttonCK()
    {
        return buttoncheck;
    }

    public bool stratCK()
    {
        return stratcheck;
    }

    public int nextCK()
    {
        return nextselect;
    }

    void Start()
    {
        //text.SetActive(false);
        data = GetComponent<RectTransform>();
        //color.a = 0;
        //RectTransform rectTransform = GetComponent<RectTransform>();
        Title.color = new Color32(255, 255, 255, 0);
    }

    
    
    void Update()
    {
        data.sizeDelta = new Vector2(sizenowW, sizenowH);
        Title.color = new Color32(255,255,255,(byte)CL_now);
        data.anchoredPosition = new Vector2(nextsizex,nextsizey);
        if (nextST == false)
        {
            if (sizecount < 1)
            {
                sizenowW = Mathf.Lerp(0, sizemaxW, sizecount);
                sizenowH = Mathf.Lerp(0, sizemaxH, sizecount);
                sizecount += 0.01F;
            }
            else if (!textcheck)
            {
                action = true;
                textcheck = true;
                starttext.SetActive(true);
            }
            if (sizecount > 0.4f && colorcount < 1)
            {
                CL_now = Mathf.Lerp(0, CL_MAX, colorcount);
                colorcount += 0.01F;
            }
        }
       
        if(nextST==true)
        {
            if (poscount < 1)
            {
                nextsizex = Mathf.Lerp(0, posxmin, poscount);
                nextsizey = Mathf.Lerp(62, posymin, poscount);
                poscount += 0.05f;
            }
            if (sizecount > 0.7f)
            {
                sizenowW = Mathf.Lerp(0, sizemaxW, sizecount);
                sizenowH = Mathf.Lerp(0, sizemaxH, sizecount);
                sizecount -= 0.015F;


            }
        }

        if (startPressed && Titletest() && !buttoncheck)
        {
            stratcheck = false;
            nextST = true;
        }

        if(aui.destroyCK())
        {
            if (!buttoncheck)
            {
                buttoncheck = true;
                button.SetActive(true);
                button2.SetActive(true);
                button3.SetActive(true);
            }
        }

       
        

        if (buttoncheck == true && upPressed && nextselect == 1)
        {
            upPressed = false;
            nextselect = 3;
            Debug.Log(nextselect);
        }
        if (buttoncheck == true && upPressed&&nextselect==2)
        {
            upPressed = false;
            nextselect = 1;
            Debug.Log(nextselect);
        }
        if (buttoncheck == true && upPressed && nextselect == 3)
        {
            upPressed = false;
            nextselect = 2;
            Debug.Log(nextselect);
        }
        if (buttoncheck == true && downPressed&&nextselect==1)
        {
            downPressed = false;
            nextselect = 2;
            Debug.Log(nextselect);
        }
        if (buttoncheck == true && downPressed && nextselect == 2)
        {
            downPressed = false;
            nextselect = 3;
            Debug.Log(nextselect);
        }
        if (buttoncheck == true && downPressed && nextselect == 3)
        {
            downPressed = false;
            nextselect = 1;
            Debug.Log(nextselect);
        }

        //if (nextselect==1&&buttoncheck == true && Input.GetAxis("Axis 7") > 0f)
        //{
        //    nextselect = 2;

        //}

        //if (buttoncheck == true && Input.GetAxis("Axis 7") < 0f)
        //{
        //    nextselect = 2;

        //}

        //if (buttoncheck == true && Input.GetAxis("Axis 7") < 0f&&nextselect==2)
        //{
        //    nextselect = 1;

        //}
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
