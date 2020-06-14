using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slidercr : MonoBehaviour
{
    //zenzai
    public DropDroplet sabu;
    public RawImage sliderImage;

    //kako
    Color cl;

    //sub
    Color cl2;

    Slider _slider;



    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = 1;
    }

    //value max
    float max = 0;

    //color set
    //0=start 1=in 2=out
    int colorset = 0;


    void Update()
    {
        if (!sabu.HasWater())
        {

            colorset = 1;
        }
        else
        {

            
            colorset = 2;
            
        }


        //watercontrol
        switch (colorset)
        {
            case 1:

                if (max > _slider.minValue)
                {

                    max -= 0.02f;

                }
                break;

            case 2:
                
                cl = sabu.GetColor();
                
                if (max < _slider.maxValue)
                {

                    max += 0.02f;
                    
                }

                break;

            default:
                break;

        }
        cl2 = Color.Lerp(cl2, sabu.GetColor(), max * 0.1f);


        sliderImage.color = cl2;



        //if (clcount < 1)
        //{

        //    clcount += 0.1f;

        //}

        //sliderImage.color = Color.Lerp(cl, sabu.GetColor(), clcount);





        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log(cl);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log(sabu.GetColor());
        }

        // value set
        _slider.value = max;
    }
}
