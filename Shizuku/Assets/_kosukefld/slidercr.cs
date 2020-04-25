using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slidercr : MonoBehaviour
{
    //zenzai
    public DropDroplet sabu;

    //kako
    Color cl;

    //sub
    Color cl2;

    public RawImage sliderImage;

    Slider _slider;









    void Start()
    {



        _slider = GameObject.Find("Slider").GetComponent<Slider>();



        _slider.maxValue = 5;

    }

    //value max
    float max = 0;

    //color set
    //0=start 1=in 2=out
    int colorset = 0;


    float clcount = 0;


    void Update()
    {


        if (!sabu.HasWater())
        {

            colorset = 1;
        }
        else
        {

            cl = sabu.GetColor();
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


        sliderImage.color = cl;



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