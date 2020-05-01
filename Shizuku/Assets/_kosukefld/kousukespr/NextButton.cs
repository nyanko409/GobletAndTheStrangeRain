using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    public TitleUI check;
    public Image textH;
    public Image textT;
    public float colorspeed = 0.05f;
    float STcount = 0;
    float count = 0;
    float CL_A = 0;
    float STCL_A = 0;
    int colorcount = 1;
    int STCLcount = 1;

    void Start()
    {
        textH.color = new Color32(255, 255, 255, 0);
        textT.color = new Color32(255, 255, 255, 0);
        //textH = this.GetComponent<Text>();
        //textT = this.GetComponent<Text>();      
    }

   
    void Update()
    {
        CL_A = Mathf.Lerp(0, 255, count);
        STCL_A = Mathf.Lerp(0, 255, STcount);
        switch (STCLcount)
        {
            case 1:
                STcount += colorspeed;
                if (STcount >= 1)
                {
                    STCLcount = 2;
                }
                break;
            case 2:
                break;
        }
        switch (colorcount)
        {
            case 1:
                count += colorspeed;
                if (count >= 1)
                {
                    colorcount = 2;
                }
                break;
            case 2:
                count -= colorspeed;
                if (count <= 0)
                {
                    colorcount = 1;
                }
                break;
        }

        switch (check.nextCK())
        {
            case 1:
                textH.color = new Color32(255, 255, 255, (byte)CL_A);
                textT.color = new Color32(255, 255, 255, 255);
                if (Input.GetKeyDown(KeyCode.JoystickButton0) == true && check.BuuttonCK() == true)
                {
                    StartCoroutine(SceneLoader.LoadSceneAsync("StageSelect", "Prefabs/UI and HUD/Loading Canvas", 3));
                    Debug.Log("osita A");
                }
                break;
            case 2:
                textH.color = new Color32(255, 255, 255, 255);
                textT.color = new Color32(255, 255, 255, (byte)CL_A);
                if (Input.GetKeyDown(KeyCode.JoystickButton0) == true && check.BuuttonCK() == true)
                {
                    StartCoroutine(SceneLoader.LoadSceneAsync("StageSelect", "Prefabs/UI and HUD/Loading Canvas", 3));
                    Debug.Log("osita A");
                }
                break;
            default:
                textT.color = new Color32(255, 255, 255, (byte)STCL_A);
                textH.color = new Color32(255, 255, 255, (byte)STCL_A);
                break;
        }

      
    }
}
