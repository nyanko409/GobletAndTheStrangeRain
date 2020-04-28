using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    public bool Titletest()
    {
        return action;
    }

    public PushAUI aui;

    public Image Title;
    public GameObject canvas;
    public GameObject starttext;
    public GameObject button;
    public GameObject button2;
    Color color;
    Color color2;
    int CL_MAX = 255;
    int nextselect = 0;
    float CL_now = 0;
    float count = 0;
    bool action = false;
    bool textcheck = false;
    bool buttoncheck = false;
    bool stratcheck = true;

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

        //color.a = 0;
        Title.color = new Color32(255, 255, 255, 0);
    }

    
    
    void Update()
    {

        //GameObject A = GameObject.Find("StartA");

        Title.color = new Color32(255,255,255,(byte)CL_now);
        if(count<=1)
        {
            CL_now = Mathf.Lerp( 0, CL_MAX, count);
            count += 0.01F;
        }
        else
        {
            if(!textcheck)
            {
                textcheck = true;
                starttext.SetActive(true);
            }
            action = true;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0) == true&&Titletest()==true&&buttoncheck==false)
        {
            stratcheck = false;           
        }

        if(aui.destroyCK()==true)
        {
            if (!buttoncheck)
            {
                buttoncheck = true;
                button.SetActive(true);
                button2.SetActive(true);
            }
        }
        if (buttoncheck == true&& Input.GetAxis("Axis 7") > 0f)
        {
            nextselect = 1;
            Debug.Log(nextselect);
        }
        if(buttoncheck == true && Input.GetAxis("Axis 7") < 0f)
        {
            nextselect = 2;
            Debug.Log(nextselect);
        }
        
    }
    
}
