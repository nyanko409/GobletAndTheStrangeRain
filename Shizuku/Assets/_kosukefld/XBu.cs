using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XBu : MonoBehaviour
{
   public PlayerController data;
   public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.color = new Color32(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!data.IsInDragRange())
        {
            image.color = new Color32(255, 255, 255, 0);
        }
        else
        {
            image.color = new Color32(255, 255, 255, 255);
        }
        Debug.Log(data.IsInDragRange());
        
    }
}
