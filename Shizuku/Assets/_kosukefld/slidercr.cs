using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class slidercr : MonoBehaviour
{
    Slider _slider;

    void Start()
    {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    //value max
    float max = 10;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            

                max -= 1;
            

        }

        if(Input.GetKey(KeyCode.T))
        {
            max = 10;
        }

        // value set
        _slider.value = max;
    }
}
