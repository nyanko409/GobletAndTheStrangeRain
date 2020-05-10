using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackImage : MonoBehaviour
{
    public TitleUI check;

    public Image image;
    private RectTransform data;

    int pos;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<RectTransform>();
        image.color = new Color32(0,255,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        data.anchoredPosition = new Vector2(500, pos);
        Debug.Log(pos);
        switch (check.nextCK())
            {
            case 1:
                //image.color = new Color32(0, 255, 0, 255);
                pos = 155;
                break;
            case 2:
               // image.color = new Color32(0, 255, 0, 255);
                pos = -39;
                break;
            case 3:
               // image.color = new Color32(0, 255, 0, 255);
                pos = -249;
                break;
            default:
               // image.color = new Color32(0, 255, 0, 0);
                break;

        }
    }
}
