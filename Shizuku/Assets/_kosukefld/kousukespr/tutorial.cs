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

    bool confirmPressed = false;

    GameInput actions;

    private void Awake()
    {
        actions = new GameInput();

        actions.UIPauseMenu.Confirm.started += context => confirmPressed = true;
        actions.UIPauseMenu.Confirm.canceled += context => confirmPressed = false;
    }
        void Start()
    {
        //starttime = 0;
    }


    void Update()
    {
        Adata.color = new Color32(255, 255, 255, (byte)CL_A);
        Xdata.color = new Color32(0, 0, 0, (byte)CL_X);
        starttime += Time.deltaTime;
        time += Time.deltaTime;
      
        if (starttime > 7.5f)
        {
            if (!check)
            {
                check = true;
                CL_A = 255;
                CL_X = 255;
                //Debug.Log("CHECK");
            }
        }
        if (confirmPressed && check == true)
        {
            CL_A = 0;
            CL_X = 0;
        }
        //if ()
        //{

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
