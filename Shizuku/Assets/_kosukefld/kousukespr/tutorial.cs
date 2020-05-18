using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public PlayerController pl;
    public DropDroplet sabu;

    public Image WTin;
    public Image WTout;
    public Image Adata;
    public Image Xdata;
    public Image move;
    public Image cameraui;

    float time;
    float starttime;
    bool check = false;
    float CL_A = 0;
    float CL_X = 0;
    float CL_WTIN = 0;
    float CL_WTOUT = 0;
    float CL_MV = 0;
    float CL_CM = 0;
    float CL_Amax = 255;
    float CL_Xmax = 255;
    float CL_MVmax = 255;
    float CL_CMmax = 255;
    float CLcountA = 0;
    float CLcountX = 0;
    float CLcountIN = 0;
    float CLcountOUT = 0;
    float CLcountMV = 0;
    float CLcountCM = 0;
    float countspeed = 0.05f;

    int secondCLcheck = 1;
    int CLcheck = 1;
    int CLcheckA = 1;
    int CLcheckX = 1;
    int CLcheckIN = 1;
    int CLcheckOUT = 1;
    int CLcheckMV = 1;
    int CLcheckCM = 1;
    int thirdCLcheck = 1;

    bool startcheck = false;
    bool colorcheck = false;
    bool colorcheck2 = false;
    bool colorcheck3 = false;
    bool endAcheck = false;
    bool endXcheck = false;
    bool fastcheck1 = false;
    bool fastcheck2 = false;
    bool secondcheck = false;
    bool endINcheck = false;
    bool endOUTcheck = false;
    bool thirdcheck = false;
    bool endMVcheck = false;
    bool endCMcheck = false;
    bool CM = false;
    bool MV = false;

    bool confirmPressed = false;
    bool isDragging = false;
    bool Dropcheck = false;
    bool movecheck = false;
    bool cameracheck = false;
    GameInput actions;

    private void Awake()
    {
        actions = new GameInput();

        actions.UIPauseMenu.leftstick.started += context => movecheck = true; 
        actions.UIPauseMenu.leftstick.canceled += context => movecheck = false;
        actions.UIPauseMenu.rightstick.started += context => cameracheck = true;
        actions.UIPauseMenu.rightstick.canceled += context => cameracheck = false;

        actions.UIPauseMenu.Confirm.started += context => confirmPressed = true;
        actions.UIPauseMenu.Confirm.canceled += context => confirmPressed = false;
        actions.Player.Drag.started += context => isDragging = true;
        actions.Player.Drag.canceled += context => isDragging = false;
        actions.Player.DropDroplet.started += context => Dropcheck = true;
        actions.Player.DropDroplet.canceled += context => Dropcheck = false;

    }
        void Start()
    {

    }


    void Update()
    {
        Debug.Log(CLcountA);
        time += Time.deltaTime;
        if (time >= 0.01f)
        {
           
            Adata.color = new Color32(255, 255, 255, (byte)CL_A);
            Xdata.color = new Color32(255, 255, 255, (byte)CL_X);
            WTin.color = new Color32(255, 255, 255, (byte)CL_WTIN);
            WTout.color = new Color32(255, 255, 255, (byte)CL_WTOUT);
            move.color = new Color32(255, 255, 255, (byte)CL_MV);
            cameraui.color = new Color32(255, 255, 255, (byte)CL_CM);
            starttime += Time.deltaTime;


            if (starttime > 0.1f)
            {
                if (!check)
                {
                    check = true;
                    startcheck = true;
                    //CL_A = 255;
                    // CL_X = 255;
                    //Debug.Log("CHECK");
                }
            }

            //start
            //==========================================================
            if (startcheck == true)
            {
                switch (CLcheck)
                {
                    case 1:
                        CL_MV = Mathf.Lerp(0, CL_MVmax, CLcountMV);
                        CL_CM = Mathf.Lerp(0, CL_CMmax, CLcountCM);
                        CLcountMV += countspeed;
                        CLcountCM += countspeed;
                        if (CLcountMV >= 1)
                        {
                            CLcheck = 2;
                        }
                        break;
                    case 2:
                        colorcheck = true;
                        break;
                }
            }

            if(secondcheck==true)
            {
                switch(secondCLcheck)
                {
                    case 1:
                        CL_A = Mathf.Lerp(0, CL_Amax, CLcountA);
                        CL_X = Mathf.Lerp(0, CL_Xmax, CLcountX);
                        CLcountA += countspeed;
                        CLcountX += countspeed;
                        if (CLcountA >= 1)
                        {
                            secondCLcheck = 2;
                        }
                        break;
                    case 2:
                        colorcheck2 = true;
                        break;
                }
            }

            if(thirdcheck==true)
            {
                switch(thirdCLcheck)
                {
                    case 1:
                        CL_WTIN= Mathf.Lerp(0, 255, CLcountIN);
                        CL_WTOUT = Mathf.Lerp(0, 255, CLcountOUT);
                        CLcountIN += countspeed;
                        CLcountOUT += countspeed;
                        if(CLcountIN>=1)
                        {
                            thirdCLcheck = 2;
                        }
                        break;
                    case 2:
                        colorcheck3 = true;
                        break;
                }
            }
            //==============================================================
            // end
            //==============================================================
            if(endAcheck==true)
            {
                switch(CLcheckA)
                {
                    case 1:
                        CL_A = Mathf.Lerp(-12, CL_Amax, CLcountA);
                        CLcountA -= countspeed;
                        if(CLcountA<=0)
                        {
                            CLcheckA = 2;
                        }
                        break;
                    case 2:
                        fastcheck1 = true;
                        break;
                }
            }

            if(endXcheck==true)
            {
                switch (CLcheckX)
                {
                    case 1:
                        CL_X = Mathf.Lerp(-12, CL_Xmax, CLcountX);
                        CLcountX -= countspeed;
                        if (CLcountX <= 0)
                        {
                            CLcheckX = 2;
                        }
                        break;
                    case 2:
                        fastcheck2 = true;
                        break;
                }
            }

            if (endINcheck == true)
            {
                switch (CLcheckIN)
                {
                    case 1:
                        CL_WTIN = Mathf.Lerp(-12, 255, CLcountIN);
                        CLcountIN -= countspeed;
                        if (CLcountIN <= 0)
                        {
                            CLcheckIN = 2;
                        }
                        break;
                    case 2:
                        break;
                }
            }
            if(endOUTcheck==true)
            {
                switch(CLcheckOUT)
                {
                    case 1:
                        CL_WTOUT = Mathf.Lerp(-12, 255, CLcountOUT);
                        CLcountOUT -= countspeed;
                        if (CLcountOUT <= 0)
                        {
                            CLcheckOUT = 2;
                        }
                        break;
                    case 2:
                        break;
                }
            }
            if (endMVcheck == true)
            {
                switch (CLcheckMV)
                {
                    case 1:
                        CL_MV = Mathf.Lerp(-12, 255, CLcountMV);
                        CLcountMV -= countspeed;
                        if (CLcountMV <= 0)
                        {
                            CLcheckMV = 2;
                        }
                            break;
                    case 2:
                        MV = true;
                        break;
                }
            }
            if (endCMcheck == true)
            {
                switch (CLcheckCM)
                {
                    case 1:
                        CL_CM = Mathf.Lerp(-12, 255, CLcountCM);
                        CLcountCM -= countspeed;
                        if (CLcountCM <= 0)
                        {
                            CLcheckCM = 2;
                        }
                        break;
                    case 2:
                        CM = true;
                        break;
                }
            }
            //========================================================
            //if
            //========================================================
            if (confirmPressed==true && colorcheck == true)
            {
                endAcheck = true;
               

            }
            if (isDragging && check == true && pl.IsInDragRange() && colorcheck == true)
            {
                endXcheck = true;
               
         
            }
            if(fastcheck1==true&&fastcheck2==true)
            {
                thirdcheck = true;
            }
            //Debug.Log(endINcheck);
            if(CM==true&&MV==true)
            {
                secondcheck = true;
            }
            if(colorcheck3==true&& sabu.HasWater()==true)
            {
                endINcheck = true;
            }
            
            if(Dropcheck==true&&endINcheck==true)
            {
                endOUTcheck = true;
            }
            if(colorcheck == true&& movecheck == true)
            {
                endMVcheck = true;
            }
            if(colorcheck==true&&cameracheck==true)
            {
                endCMcheck = true;
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
