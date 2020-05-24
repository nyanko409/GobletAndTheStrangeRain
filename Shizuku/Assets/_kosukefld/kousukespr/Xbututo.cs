using UnityEngine;
using UnityEngine.UI;

public class Xbututo : MonoBehaviour
{
    public PlayerController data;
    public TestTL2 CK;
    public Image image;


    void Start()
    {
        image.color = new Color32(255,255,255,0);
    }
    void Update()
    {
        Debug.Log(CK.CK2());
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
    }
}
