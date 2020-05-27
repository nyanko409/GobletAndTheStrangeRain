using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aicon : MonoBehaviour
{
    public TitleUI title;

    float startposx = 22;
    float startposy = -117;
    float rastposx = 384;
    float rastposy = 131;
    float nowposx = 0;
    float nowposy = 0;
    float count = 0;
    float maintime = 0;
    float time = 0;

    float timeCK = 1;

    private RectTransform data;

    void Start()
    {
        data = GetComponent<RectTransform>();
    }

    
    void Update()
    {
        //data.anchoredPosition = new Vector2(nowposx,nowposy);
        //nowposx = Mathf.Lerp(startposx, rastposx, count);
        //nowposy = Mathf.Lerp(startposy, rastposy, count);
        //maintime += Time.deltaTime;
        //if (maintime >= 0.01f)
        //{
        //    if(title.TIME()>=1.5f)
        //    {
        //        switch(timeCK)
        //        {
        //            case 1:
                       
        //                count += 0.01f;
        //                 if (count >= 1)
        //                    {
        //                        timeCK = 2;
        //                    }
        //                break;
        //            case 2:

        //                break;
        //        }
        //    }
            
        //    maintime = 0;
        //}
    }
}
