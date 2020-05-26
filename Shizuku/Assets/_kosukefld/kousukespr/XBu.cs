using UnityEngine;
using UnityEngine.UI;

public class XBu : MonoBehaviour
{
   public PlayerController data;
   public Image image;


    // Update is called once per frame
    void Update()
    {
        if(data.IsInDragRange())
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }
}
