using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class slidercr : MonoBehaviour
{
    
    


    public RawImage sliderImage;

    Slider _slider;

    //color
    GameObject fill;

    void Start()
    {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();

        //color get
        fill = GameObject.Find("Fill");

        _slider.maxValue = 5;

    }

    //value max
    float max = 0;

    //color set
    //0=start 1=in 2=out
    int colorset = 0;

    //1=red 2=blue
    int colorCode = 1;

    //red
    byte CL_R = 0;

    //green
    byte CL_G = 0;

    //blue
    byte CL_B = 0;

    void Update()
    {

        //water in
        if (Input.GetKeyDown(KeyCode.R))
        {
            colorset = 1;
        }

        //water out
        if (Input.GetKeyDown(KeyCode.T))
        {
            colorset = 2;
        }

        //watercontrol
            switch (colorset)
        {
            case 1:
                if (max > _slider.minValue)
                {

                    max -= 0.025f;
                }
                break;

            case 2:
                if (max < _slider.maxValue)
                {

                    max += 0.025f;
                }
                break;

            default:
                break;
        }

        sliderImage.color = new Color32(CL_R, CL_G, CL_B, 255);

        //colorcontrol
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (colorCode == 1)
            {
                colorCode = 2;
            } else if (colorCode == 2)
            {
                colorCode = 1;
            }
        }
        switch(colorCode)
        {
            case 1://red
                if(CL_R<255)
                {
                    CL_R += 1;
                }
                if(CL_G>0)
                {

                    CL_G -= 1;
                }
                if (CL_B > 0)
                {

                    CL_B -= 1;
                }

                break;
            case 2://blue
                if (CL_R > 0)
                {

                    CL_R -= 1;
                }

                if (CL_G < 255)
                {
                    CL_G += 1;
                }
                if (CL_B < 255)
                {
                    CL_B += 1;
                }
                break;
            default:
                break;
        }
        //sliderImage.color = new Color32(CL_R,CL_G,CL_B, 255);
        //if(Input.GetKeyDown(KeyCode.Y))
        //{
        //    if (nextcolorCode == 1)
        //    {
        //        sliderImage.color = new Color32(255, 0, 0, 255);

        //        nextcolorCode = 2;

        //    }else if(nextcolorCode==2)
        //    {
        //        sliderImage.color = new Color32(0, 255, 255, 255);

        //        nextcolorCode = 1;
        //    }
        //}

        // value set
        _slider.value = max;
    }
}
