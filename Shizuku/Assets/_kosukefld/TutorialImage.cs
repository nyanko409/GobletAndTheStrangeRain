using UnityEngine;
using UnityEngine.UI;

public class TutorialImage : MonoBehaviour
{
    public GameObject Main;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;
    public GameObject Image6;
    public GameObject Image7;

    public RectTransform data1;
    public RectTransform data2;
    public RectTransform data3;
    public RectTransform data4;
    public RectTransform data5;
    public RectTransform data6;
    public RectTransform data7;

    public float moveSpeed;

    float count1;
    float count2;
    float count3;
    float count4;
    float count5;
    float count6;
    float count7;


    float woldtime;
    int Lcount=1;
    int count=1;
    float pos1 = 0;
    float pos2 = 2110;
    float pos3 = 2110;
    float pos4 = 2110;
    float pos5 = 2110;
    float pos6 = 2110;
    float pos7 = 2110;
   
    bool STCK = false;
    bool moveCK=true;

    bool upPressed;
    bool downPressed;
    private GameInput actions;

    private void ImageCK(bool a, bool b, bool c, bool d, bool e, bool f,bool g)
    {
        Image1.SetActive(a);
        Image2.SetActive(b);
        Image3.SetActive(c);
        Image4.SetActive(d);
        Image5.SetActive(e);
        Image6.SetActive(f);
        Image7.SetActive(g);
    }
    private void Awake()
    {
        actions = new GameInput();

        actions.TutorialMenu.NextUI.started+= context => { upPressed = true; };
        actions.TutorialMenu.NextUI.canceled += context => { upPressed = false; };

        actions.TutorialMenu.BackUI.started += context => { downPressed= true; };
        actions.TutorialMenu.BackUI.canceled += context => { downPressed = false; };
    }

        
        void Start()
    {
       

        Time.timeScale = 0;
        ImageCK(true,true, true, true, true, true, true);
    }

  
    void Update()
    {
        data1.anchoredPosition = new Vector2(pos1, 0);
        data2.anchoredPosition = new Vector2(pos2, 0);
        data3.anchoredPosition = new Vector2(pos3, 0);
        data4.anchoredPosition = new Vector2(pos4, 0);
        data5.anchoredPosition = new Vector2(pos5, 0);
        data6.anchoredPosition = new Vector2(pos6, 0);
        data7.anchoredPosition = new Vector2(pos7, 0);

        //Debug.Log(Time.deltaTime);
        woldtime += 0.016f;
        if (woldtime >= 0.01f)
        {
            if (upPressed&&moveCK)
            {

                upPressed = false;
                if (count < 8)
                {
                    count += 1;
                }

            }

            if (downPressed&&moveCK)
            {
                downPressed = false;
                if (count > 1)
                {
                    count -= 1;
                }

            }

            switch (count)
            {
                case 1:
                    // ImageCK(true, false, false, false, false, false, false);

                    //1&2
                    if (Lcount == 1)
                    {
                        if (pos1 > 0)
                        {

                            moveCK = false;
                            pos1 -= moveSpeed;
                        }
                        else
                        {
                            pos1 = 0;
                            moveCK = true;
                            Lcount = 1;
                        }
                    }

                    if (Lcount==2)
                    {
                        if(pos1<0)
                        {
                            moveCK = false;
                            pos1 += moveSpeed;
                            pos2 += moveSpeed;
                        }
                        else
                        {
                            pos1 = 0;
                            pos2 = 2110;
                            moveCK = true;
                            Lcount = 1;
                        }
                    }

                    break;

                case 2:
                   //1&2
                    if(Lcount==1)
                    {
                      
                        if(pos2>0)
                        {
                            moveCK = false;
                            pos1 -= moveSpeed;
                            pos2 -= moveSpeed;
                        }
                        else
                        {
                            pos1 = -2110;
                            pos2 = 0;
                            moveCK = true;
                            Lcount = 2;
                        }

                    }
                    //2&3
                    if(Lcount==3)
                    {
                        if (pos2 < 0)
                        {
                            moveCK = false;
                            pos2 += moveSpeed;
                            pos3 += moveSpeed;
                        }
                        else
                        {
                            pos2 = 0;
                            pos3 = 2110;
                            moveCK = true;
                            Lcount = 2;
                        }
                    }

                    
                    break;

                case 3:
                    //2&3
                    if (Lcount == 2)
                    {

                        if (pos3 > 0)
                        {
                            moveCK = false;
                            pos2 -= moveSpeed;
                            pos3 -= moveSpeed;
                        }
                        else
                        {
                            pos2 = -2110;
                            pos3 = 0;
                            moveCK = true;
                            Lcount = 3;
                        }

                    }
                    //3&4
                    if (Lcount == 4)
                    {
                        if (pos3 < 0)
                        {
                            moveCK = false;
                            pos3 += moveSpeed;
                            pos4 += moveSpeed;
                        }
                        else
                        {
                            pos3 = 0;
                            pos4 = 2110;
                            moveCK = true;
                            Lcount = 3;
                        }
                    }

                 
                    break;

                case 4:

                    //3&4
                    if (Lcount == 3)
                    {

                        if (pos4 > 0)
                        {
                            moveCK = false;
                            pos3 -= moveSpeed;
                            pos4 -= moveSpeed;
                        }
                        else
                        {
                            pos3 = -2110;
                            pos4 = 0;
                            moveCK = true;
                            Lcount = 4;
                        }

                    }

                    //4&5
                    if (Lcount == 5)
                    {
                        if (pos4 < 0)
                        {
                            moveCK = false;
                            pos4 += moveSpeed;
                            pos5 += moveSpeed;
                        }
                        else
                        {
                            pos4 = 0;
                            pos5 = 2110;
                            moveCK = true;
                            Lcount = 4;
                        }
                    }

                   
                    break;

                case 5:
                    //4&5
                    if (Lcount == 4)
                    {

                        if (pos5 > 0)
                        {
                            moveCK = false;
                            pos4 -= moveSpeed;
                            pos5 -= moveSpeed;
                        }
                        else
                        {
                            pos4 = -2110;
                            pos5 = 0;
                            moveCK = true;
                            Lcount = 5;
                        }

                    }
                    //5&6
                    if (Lcount == 6)
                    {
                        if (pos5 < 0)
                        {
                            moveCK = false;
                            pos5 += moveSpeed;
                            pos6 += moveSpeed;
                        }
                        else
                        {
                            pos5 = 0;
                            pos6 = 2110;
                            moveCK = true;
                            Lcount = 5;
                        }
                    }
                    break;

                case 6:
                    //5&6
                    if (Lcount == 5)
                    {

                        if (pos6 > 0)
                        {
                            moveCK = false;
                            pos5 -= moveSpeed;
                            pos6 -= moveSpeed;
                        }
                        else
                        {
                            pos5 = -2110;
                            pos6 = 0;
                            moveCK = true;
                            Lcount = 6;
                        }

                    }
                    //6&7
                    if (Lcount == 7)
                    {
                        if (pos6 < 0)
                        {
                            moveCK = false;
                            pos6 += moveSpeed;
                            pos7 += moveSpeed;
                        }
                        else
                        {
                            pos6 = 0;
                            pos7 = 2110;
                            moveCK = true;
                            Lcount = 6;
                        }
                    }
                    break;

                case 7:
                    //6&7
                    if (Lcount == 6)
                    {

                        if (pos7 > 0)
                        {
                            moveCK = false;
                            pos6 -= moveSpeed;
                            pos7 -= moveSpeed;
                        }
                        else
                        {
                            pos6 = -2110;
                            pos7 = 0;
                            moveCK = true;
                            Lcount = 7;
                        }

                    }
                    break;

                case 8:
                  
                    Time.timeScale = 1;
                    Main.SetActive(false);

                    break;

                default:
                    break;
            }
            woldtime = 0;
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
