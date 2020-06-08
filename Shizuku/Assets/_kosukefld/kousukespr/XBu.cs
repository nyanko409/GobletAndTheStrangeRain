using UnityEngine;
using UnityEngine.UI;

public class XBu : MonoBehaviour
{
    public DropDroplet sabu;
    public PlayerController data;
   public Image image;
    public Image WT;
    public Image WT2;

    // Update is called once per frame
    void Update()
    {
        if (sabu.CanDrop())
        {
            WT.enabled = true;
            WT2.enabled = true;
        }
        else
        {
            WT.enabled = false;
            WT2.enabled = false;
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
