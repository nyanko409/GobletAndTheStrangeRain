using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseSelect : MonoBehaviour
{


    public Image CLdata;
    public RectTransform data;

    bool check = false;
    bool Bcheck = true;

    float nowW = 0;
    float nowH = 0;
    int Wmax = 1200;
    int Hmax = 700;
    float SZcount = 0;
    float countSpeed = 0.1f;

    void Start()
    {
        data = GetComponent<RectTransform>();
        data.sizeDelta = new Vector2(0, 0);
    }


    void Update()
    {
        data.sizeDelta =new Vector2(nowW, nowH);
        nowW = Mathf.Lerp(0, Wmax ,SZcount);
        nowH = Mathf.Lerp(0, Hmax, SZcount);
        if (Input.GetKeyDown(KeyCode.JoystickButton7) == true&&check==false)
        {
           
            check = true;
            //Debug.Log(check);

        }

        if (check == true)
        {
            if (SZcount < 1)
            {
                SZcount += countSpeed;
            }
            if(SZcount>1)
            {
                check = false;
                Debug.Log(check);
            }
          

        }

        


    }
}
