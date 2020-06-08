using UnityEngine;
using UnityEngine.UI;

public class Xbututo : MonoBehaviour
{
    public DropDroplet sabu;
    public PlayerController data;
    public TestTL2 CK;
    public Image image;
    public Image WT;
    public Image WT2;


    void Start()
    {
        //WT.color = new Color32(255, 255, 255, 0);
        image.color = new Color32(255,255,255,0);
    }
    void Update()
    {
            //Debug.Log(CK.CK2());

            if (CK.CK2()==true)
        {
            

            image.color = new Color32(255, 255, 255, 255);
            if (data.IsInDragRange())
            {
                image.enabled = true;
            }
            else
            {
                image.enabled = false;
            }
        }
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
    }
}
