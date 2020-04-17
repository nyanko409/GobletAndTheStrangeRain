using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ski : MonoBehaviour
{

    RawImage rawImage;
    Rect uvRect;

    //nami tuyosa
    const float maxBar = 0.8f;

    const float max = 100;

    [SerializeField] float currentHBar;

    //nami kasoku
    [SerializeField] float currentBar = 0f;

    //目指すダメージのバーの長さ
    [SerializeField] float nextBar;

    //バーが移動するスピード
    [SerializeField] float speed = 2f;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
        rawImage.uvRect = new Rect(0.05f, 0f, 0.49f, 1f);

        currentHBar = maxBar / max;
    }

    void Update()
    {

        rawImage.uvRect = new Rect(currentBar, 0f, 0.49f, 1f);

        //Mathf.LerpでcurrentDamgeBarからnestDamageBarに移動させる
        currentBar = Mathf.Lerp(currentBar, nextBar,
            speed * Time.deltaTime);

        
        nextBar += currentHBar ;
        

       
        
        if(currentBar>0.33)
        {
            currentBar = 0;
        }

        if (nextBar > maxBar)
        {
            nextBar = maxBar;
        }

    }
}