using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pauseback : MonoBehaviour
{
    public PauseSelect check;

    private RectTransform data;

    int size;
    int BSTcount;
    float Bcount;
    float Bcountspeed;
    float Bpos = 0;
    float Bposnext;
    float Bpospast;
    bool BCcheck=false;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
       
        data.anchoredPosition = new Vector2(0, check.BposCK());
        data.sizeDelta = new Vector2(check.BsizeCK(),100);
        //Bpos = Mathf.Lerp(Bpospast, Bposnext, Bcount);
       // Debug.Log(check.BposCK());
        //switch (BSTcount)
        //{
        //    case 1:
        //        Bcount += Bcountspeed;
        //        if (Bcount >= 1)
        //        {
        //            BSTcount = 2;
        //        }
        //        break;
        //    case 2:
        //        BCcheck = false;
        //        break;
        //}
        //switch (check.nextCK())
        //{
        //    case 1:
        //        //if (!BCcheck)
        //        //{

        //            Bcount = 0;
        //            BSTcount = 1;
        //            BCcheck = true;
        //            Bpospast = Bpos;
        //            Bposnext = 64;
        //            size = 200;
                
        //        break;
        //    case 2:
                

        //            Bcount = 0;
        //            BSTcount = 1;
        //            BCcheck = true;
        //            Bpospast = Bpos;
        //            Bposnext = -21;
        //        size = 400;
                
        //        break;
        //    case 3:
                

        //            Bcount = 0;
        //            BSTcount = 1;
        //            BCcheck = true;
        //            Bpospast = Bpos;
        //            Bposnext = -108;
        //        size = 500;
                
        //        break;
        //    case 4:
                

        //            Bcount = 0;
        //            BSTcount = 1;
        //            BCcheck = true;
        //            Bpospast = Bpos;
        //            Bposnext = -195;
        //        size = 400;
                
        //        break;
        //}
    }
}
