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

    
    public Image Title;
    public GameObject canvas;
    public GameObject starttext;
    public GameObject button;
    public GameObject button2;
    Color color;
    Color color2;
    int CL_MAX = 255;
    float CL_now = 0;
    float count = 0;
    bool action = false;
    bool textcheck = false;
    bool buttoncheck = false;

    public bool BuuttonCK()
    {
        return buttoncheck;
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
            Destroy(starttext);
            if (!buttoncheck)
            {
                buttoncheck = true;
                button.SetActive(true);
                button2.SetActive(true);
            }
            Debug.Log("push A");

            
        }

        //Title.color = new Color32(255, 255, 255, 255);
    }
    
}
