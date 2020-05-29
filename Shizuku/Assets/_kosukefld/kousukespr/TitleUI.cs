using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    

    public PushAUI aui;

    public GameObject Title;
    public Image bobre;
    public Image gobreaicn;
    public Image mizu;
    public Image RAIN;
    public Image BacLT;
    public GameObject starttext;
    public GameObject button;
    public GameObject button2;
    public GameObject button3;
    public GameObject back;

    private RectTransform data;

    Color color;
    Color color2;

    int CL_MAX = 255;
    int sizemaxW = 1;
    int sizemaxH = 1;
    int nextselect = 1;
    public  float posxmin = -573;
    public float posymin = 289;
    float poscount = 0;
    float sizenowW = 1;
    float sizenowH = 1;
    float CL_now = 0;
    float CL_now2 = 0;
    float CL_now3 = 255;
    float CL_now4 = 0;
    float sizecount = 1;
    float colorcount = 0;
    float colorcount2 = 0;
    float colorcount3 = 0;
    float colorcount4 = 0;
    float nextsizex = 0;
    float nextsizey = 62;
    float time = 0;
    float time2 = 0;

    bool timeCK = false;
    bool nextST = false;
    bool action = false;
    bool textcheck = false;
    bool buttoncheck = false;
    bool stratcheck = true;

    private GameInput actions;
    bool upPressed = false, downPressed = false;
    bool startPressed = false;

    
    private void TLcolor(float x,float y,float z,float a)//x=bobre y=rain
    {
        bobre.color = new Color32(255, 255, 255, (byte)x);
        gobreaicn.color = new Color32(255, 255, 255, (byte)x);
        mizu.color = new Color32(255, 255, 255, (byte)a);
        RAIN.color = new Color32(255, 255, 255, (byte)y);
        BacLT.color = new Color32(0, 0, 0, (byte)z);
    }

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

    public float TIME()
    {
        return time2;
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
        TLcolor(0,0,255,0);
    }

    
    
    void Update()
    {

        Debug.Log(sizecount);
        
        time2 += Time.deltaTime;
        time += Time.deltaTime;
        if (time >= 0.01f)
        {
           

            
            data.localScale = new Vector2(sizenowW, sizenowH);
            TLcolor(CL_now,CL_now2,CL_now3,CL_now4);
            //Title.color = new Color32(255, 255, 255, (byte)CL_now);
            data.anchoredPosition = new Vector2(nextsizex, nextsizey);
            if (time2 >= 1)
            {
                timeCK = true;
            }
            if(timeCK==true)
            { 
                if (nextST == false)
                {
                    if (colorcount2 < 1)
                    {
                        //sizenowW = Mathf.Lerp(0, sizemaxW, sizecount);
                        //sizenowH = Mathf.Lerp(0, sizemaxH, sizecount);
                        
                    }
                    else if (!textcheck)
                    {
                        action = true;
                        textcheck = true;
                        starttext.SetActive(true);
                    }

                    //================================================
                    //bacLT
                    if(action==true)
                    {
                        CL_now3 = Mathf.Lerp(255, 0, colorcount3);
                        colorcount3 += 0.05f;
                    }


                    if (time2>=3.0f && colorcount < 1)//time
                    {
                        CL_now = Mathf.Lerp(0, CL_MAX, colorcount);
                        colorcount += 0.01F;
                    }
                    if (time2 >= 4.0f && colorcount2 < 1)//time
                    {
                        CL_now2 = Mathf.Lerp(0, CL_MAX, colorcount2);
                        colorcount2 += 0.01F;
                    }
                    if(time2>=4.0f&&colorcount4<1)
                    {
                        CL_now4 = Mathf.Lerp(0, 24, colorcount4);
                        colorcount4 += 0.01F;
                    }
                }
            }

            if (nextST == true)
            {
                if (poscount < 1)
                {
                    nextsizex = Mathf.Lerp(0, posxmin, poscount);
                    nextsizey = Mathf.Lerp(62, posymin, poscount);
                    poscount += 0.05f;
                }
                if (sizecount>0.7f)
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

            if (aui.destroyCK())
            {
                if (!buttoncheck)
                {
                    buttoncheck = true;
                    button.SetActive(true);
                    button2.SetActive(true);
                    button3.SetActive(true);
                    back.SetActive(true);

                }
            }




            if (buttoncheck == true && upPressed && nextselect == 1)
            {
                upPressed = false;
                nextselect = 3;
                Debug.Log(nextselect);
            }
            if (buttoncheck == true && upPressed && nextselect == 2)
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
            if (buttoncheck == true && downPressed && nextselect == 1)
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
            time = 0;
            if(time2>=10)
            {
                time2 = 0;
            }
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
