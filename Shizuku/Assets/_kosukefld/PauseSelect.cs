using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseSelect : MonoBehaviour
{


    public Image CLdata;
    public RectTransform data;
    public GameObject pose;
    public GameObject restart;
    public GameObject check;
    public GameObject remap;

    //bool check = false;
    bool Bcheck = false;
    bool axsiCK = true;

    float nowW = 0;
    float nowH = 0;
    int Wmax = 770;
    int Hmax = 470;
    int nextselect = 1;
    float SZcount = 0;
    float countSpeed = 0.1f;

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
        data.sizeDelta =new Vector2(nowW, nowH);
        nowW = Mathf.Lerp(0, Wmax, SZcount);
        nowH = Mathf.Lerp(0, Hmax, SZcount);
        if (Input.GetKeyDown(KeyCode.JoystickButton7) == true/*&&check==false*/)
        {
           
            Bcheck = !Bcheck;
            Debug.Log(check);

        }
        if (Bcheck == true)
        {

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
        else
        if (Bcheck == false)
        {
            Active(false);
           
            if (SZcount > 0)
            {
                SZcount -= countSpeed;

            }
        }
        //
        if (Input.GetAxis("Axis 7") == 0f && axsiCK == false)
        {
            axsiCK = true;
        }
        if (Input.GetAxis("Axis 7") < 0f&&axsiCK==true&&nextselect==1&& Bcheck == true)
        {
            nextselect = 2;
            axsiCK = false;
            
        }
        if(Input.GetAxis("Axis 7") < 0f && axsiCK == true&&nextselect==2 && Bcheck == true)
        {
            nextselect = 3;
            axsiCK = false;
            
        }
        if (Input.GetAxis("Axis 7") < 0f && axsiCK == true && nextselect == 3 && Bcheck == true)
        {
            nextselect = 1;
            axsiCK = false;
            
        }
        if (Input.GetAxis("Axis 7") > 0f && axsiCK == true && nextselect == 1 && Bcheck == true)
        {
            nextselect = 3;
            axsiCK = false;
            
        }
        if (Input.GetAxis("Axis 7") > 0f && axsiCK == true && nextselect == 3 && Bcheck == true)
        {
            nextselect = 2;
            axsiCK = false;
           
        }
        if (Input.GetAxis("Axis 7") > 0f && axsiCK == true && nextselect == 2 && Bcheck == true)
        {
            nextselect = 1;
            axsiCK = false;
            
        }



    }
}
