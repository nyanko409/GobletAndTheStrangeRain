using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public PlayerController pl;

    public Image Adata;
    public Image Xdata;
    float time;
    float starttime;
    bool check = false;
    float CL_A = 0;
    float CL_X = 0;
    float CL_Amax = 255;
    float CL_Xmax = 255;
    float CLcountA = 0;
    float CLcountX = 0;
    float countspeed = 0.01f;

    int CLcheck = 1;
    int CLcheckA = 1;
    int CLcheckX = 1;

    bool startcheck = false;
    bool colorcheck = false;
    bool endAcheck = false;
    bool endXcheck = false;

    bool confirmPressed = false;
    bool isDragging = false;
    GameInput actions;

    private void Awake()
    {
        actions = new GameInput();

        actions.UIPauseMenu.Confirm.started += context => confirmPressed = true;
        actions.UIPauseMenu.Confirm.canceled += context => confirmPressed = false;
        actions.Player.Drag.started += context => isDragging = true;
        actions.Player.Drag.canceled += context => isDragging = false;
    }
        void Start()
    {
        //starttime = 0;
    }


    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.01f)
        {
          
            Adata.color = new Color32(255, 255, 255, (byte)CL_A);
            Xdata.color = new Color32(255, 255, 255, (byte)CL_X);
            starttime += Time.deltaTime;


            if (starttime > 7.5f)
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
            if (startcheck == true)
            {
                switch (CLcheck)
                {
                    case 1:
                        CL_A = Mathf.Lerp(0, CL_Amax, CLcountA);
                        CL_X = Mathf.Lerp(0, CL_Xmax, CLcountX);
                        CLcountA += countspeed;
                        CLcountX += countspeed;
                        if (CLcountA >= 1)
                        {
                            CLcheck = 2;
                        }
                        break;
                    case 2:
                        colorcheck = true;
                        break;
                }
            }
            if(endAcheck==true)
            {
                switch(CLcheckA)
                {
                    case 1:
                        CL_A = Mathf.Lerp(0, CL_Amax, CLcountA);
                        CLcountA -= countspeed;
                        if(CLcountA<=0)
                        {
                            CLcheckA = 2;
                        }
                        break;
                    case 2:
                        break;
                }
            }
            if(endXcheck==true)
            {
                switch (CLcheckX)
                {
                    case 1:
                        CL_X = Mathf.Lerp(0, CL_Xmax, CLcountX);
                        CLcountX -= countspeed;
                        if (CLcountX <= 0)
                        {
                            CLcheckX = 2;
                        }
                        break;
                    case 2:
                        break;
                }
            }
            if (confirmPressed && colorcheck == true)
            {
                endAcheck = true;
               

            }
            if (isDragging && check == true && pl.IsInDragRange() && colorcheck == true)
            {
                endXcheck = true;
               
         
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
