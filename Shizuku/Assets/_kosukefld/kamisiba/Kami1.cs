using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kami1 : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;

    int count = 1;
    float woldtime;
    float time;


    private void ImageCK(bool a, bool b, bool c)
    {
        image1.SetActive(a);
        image2.SetActive(b);
        image3.SetActive(c);

    }
    void Start()
    {
        ImageCK(true, false, false);
    }


    void Update()
    {
        woldtime += 0.015f;
        time += 0.015f;
        if (woldtime >= 0.01f)
        {
            if (time >= 0.75f)
            {
                count += 1;
                time = 0;
            }
            if (count == 4)
            {
                count = 1;
            }
            woldtime = 0;
        }

        switch (count)
        {
            case 1:
                ImageCK(true, false, false);
                break;
            case 2:
                ImageCK(false, true, false);
                break;
            case 3:
                ImageCK(false, false, true);
                break;
        }
    }
}
