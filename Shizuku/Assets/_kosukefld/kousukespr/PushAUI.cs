using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PushAUI : MonoBehaviour
{
    public Text text;
    public float colorspeed = 0.05f;
    float count = 0;
    float CL_A = 0;
    int colorcount = 1;
   

    void Start()
    {
       text =  this.GetComponent<Text>();
        text.color = new Color32(255, 255, 255, 0);
    }

    
    void Update()
    {
        CL_A = Mathf.Lerp(0, 255, count);
        text.color = new Color32(255, 255, 255, (byte)CL_A);

        
        switch (colorcount)
        {
            case 1:
                count += colorspeed;
               if(count>=1)
                {
                    colorcount = 2;
                }
                break;
            case 2:
                count -= colorspeed;
                if(count<=0)
                {
                    colorcount = 1;
                }
                break;
        }
            //count += 0.01F;
        
        

    }
}
