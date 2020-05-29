using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PushAUI : MonoBehaviour
{
    public AudioSource SE;
    public TitleUI titleui;
    public GameObject data;

    public Image image;
    public float colorspeed = 0.02f;
    public float Destroyspeed = 0.05f;
    float time = 0;
    float time2 =0;
    float count = 0;
    float CL_A = 0;
    int colorcount = 1;
    bool Destroyswitch = false;
    bool STcheck = true;
    bool STcheck2 = true;

    public bool destroyCK()
    {
        return Destroyswitch;
    }

    void Start()
    {
        SE = this.GetComponent<AudioSource>();
        image =  this.GetComponent<Image>();
        image.color = new Color32(255, 255, 255, 0);
    }


    void Update()
    {
        
        time += Time.deltaTime;
        if (time >= 0.01f)
        {
            CL_A = Mathf.Lerp(0, 255, count);
            image.color = new Color32(255, 255, 255, (byte)CL_A);

            if (titleui.stratCK() == true)
            {
                switch (colorcount)
                {
                    case 1:
                        count += colorspeed;
                        if (count >= 1)
                        {
                            colorcount = 2;
                        }
                        break;
                    case 2:
                        count -= colorspeed;
                        if (count <= 0)
                        {
                            colorcount = 1;
                        }
                        break;
                }
            }
            else

            if (titleui.stratCK() == false)
            {
               
                time2 += Time.deltaTime;
                if (STcheck)
                {
                    count = 1;
                    STcheck = false;
                    
                }
                if (time2 >= 0.2f)
                {
                    count = 0;
                 
                        Destroyswitch = true;
                        
                        //data.SetActive(false);
                    
                    
                }
            }

            switch(STcheck)
            {
                case true:
                    break;
                case false:
                    if(STcheck2)
                    {
                        STcheck2 = false;
                        SE.Play();
                    }
                    break;
            }
                
            

        }
        time = 0;
    }
}
