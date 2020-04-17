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

    //1=red 2=blue
    int nextcolorCode = 1;

    void Update()
    {
        


        if(Input.GetKeyDown(KeyCode.R))
        {
            if (max > _slider.minValue)
            {

                max -= 1;
            }

        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            if (max < _slider.maxValue)
            {
                max += 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            if (nextcolorCode == 1)
            {
                sliderImage.color = new Color32(255, 0, 0, 208);

                nextcolorCode = 2;

            }else if(nextcolorCode==2)
            {
                sliderImage.color = new Color32(0, 215, 255, 208);

                nextcolorCode = 1;
            }
        }

        // value set
        _slider.value = max;
    }
}
