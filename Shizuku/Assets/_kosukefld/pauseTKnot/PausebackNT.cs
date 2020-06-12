using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausebackNT : MonoBehaviour
{
    public NotTCPauseslect check;

    private RectTransform data;

    int size;
    int BSTcount;
    float Bcount;
    float Bcountspeed;
    float Bpos = 0;
    float Bposnext;
    float Bpospast;
    bool BCcheck = false;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Time.deltaTime);
        data.anchoredPosition = new Vector2(0, check.BposCK());
        data.sizeDelta = new Vector2(check.BsizeCK(), 100);
    }
}
