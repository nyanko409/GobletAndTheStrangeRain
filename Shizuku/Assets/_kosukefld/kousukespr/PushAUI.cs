using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PushAUI : MonoBehaviour
{
    public TitleUI titleui;

    public Image image;
    public float colorspeed = 0.05f;
    public float Destroyspeed = 0.01f;
    float count = 0;
    float CL_A = 0;
    int colorcount = 1;
    bool Destroyswitch = false;
   
    public bool destroyCK()
    {
        return Destroyswitch;
    }

    void Start()
    {
        image=  this.GetComponent<Image>();
        image.color = new Color32(255, 255, 255, 0);
    }

    
    void Update()
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
        }else
            
        if(titleui.stratCK()==false)
        {
            count -= Destroyspeed;
            if (count <= 0)
            {
                Destroyswitch = true;

                Destroy(this.gameObject);
            }
        }
        

    }
}
