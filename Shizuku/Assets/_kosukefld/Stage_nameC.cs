using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage_nameC : MonoBehaviour
{
    public Image data;
    public float FadeSpeed;
    public float FadeInStartTime;
    public float FadeOutStartTime;

    float Woldtime;
    float time;

    float CL_A=0;
    float count;
    bool colorswitch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        data.color = new Color32(255, 255, 255, (byte)CL_A);
        time += Time.deltaTime;
        Woldtime += Time.deltaTime;

        if(Woldtime>=0.01f)
        {
            if(time>= FadeInStartTime)
            {
                colorswitch = true;
            }
            if(time>= FadeOutStartTime)
            {
                colorswitch = false;
            }
            
            if(colorswitch)
            {
                CL_A = Mathf.Lerp(0, 255, count);
                    count += FadeSpeed;
            }
            else
            {
                CL_A = Mathf.Lerp(0, 255, count);
                count -= FadeSpeed;
            }
            Woldtime = 0;
        }

    }
}
