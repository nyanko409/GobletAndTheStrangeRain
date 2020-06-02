using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTitle : MonoBehaviour
{
    public Image end;
    public NextButton data;

    float CL_A=0;
    float count;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        end.color = new Color32(0, 0, 0,(byte) CL_A);
        CL_A = Mathf.Lerp(0,255,count);
        if (data.ADCKc())
        {
            count += 0.01f;
        }
    }
}
