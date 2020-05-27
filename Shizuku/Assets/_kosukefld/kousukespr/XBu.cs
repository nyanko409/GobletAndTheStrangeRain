using UnityEngine;
using UnityEngine.UI;

public class XBu : MonoBehaviour
{
    public DropDroplet sabu;
    public PlayerController data;
   public Image image;
    public Image WT;

    // Update is called once per frame
    void Update()
    {
        if (sabu.HasWater())
        {
            WT.enabled = true;
        }
        else
        {
            WT.enabled = false;
        }
        if (data.IsInDragRange())
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }
}
