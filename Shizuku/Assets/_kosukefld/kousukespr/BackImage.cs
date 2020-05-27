using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackImage : MonoBehaviour
{
    public TitleUI check;

    public Image image;
    private RectTransform data;

    float time = 0;
    float count=0;
    float posnext=0;
    float pos=155;
    float pospast=0;
    float countspeed = 0.2f;

    int STcount;

    bool Ccheck = false;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<RectTransform>();
        image.color = new Color32(0,255,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.01f)
        {
            data.anchoredPosition = new Vector2(500, posnext);
           // Debug.Log(pos);
            pos = Mathf.Lerp(pospast, posnext, count);
            switch (STcount)
            {
                case 1:
                    count += countspeed;
                    if (count >= 1)
                    {
                        STcount = 2;
                    }
                    break;
                case 2:
                    Ccheck = false;
                    break;
            }
            switch (check.nextCK())
            {
                case 1:
                   
                    if(!Ccheck)
                    {

                        count = 0;
                        STcount = 1;
                        Ccheck = true;
                        pospast = pos;
                        posnext = 155;
                    }
                  
                
                    break;

                case 2:
                   
                    if (!Ccheck)
                    {
                        count = 0;
                        STcount = 1;
                        Ccheck = true;
                        pospast = pos;
                        posnext = -39;
                    }
                
                   
                    break;

                case 3:
                   
                    if (!Ccheck)
                    {
                        count = 0;
                        STcount = 1;
                        Ccheck = true;
                        pospast = pos;
                        posnext = -249;
                    }
                  
                  
                    break;

                default:
                    
                    break;

            }
            time = 0;
        }
    }
}
