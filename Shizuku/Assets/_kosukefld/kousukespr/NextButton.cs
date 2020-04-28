using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    public TitleUI check;
    public Text textH;
    public Text textT;
    public float colorspeed = 0.05f;
    float count = 0;
    float CL_A = 0;
    int colorcount = 1;

    void Start()
    {
        //textH = this.GetComponent<Text>();
        //textT = this.GetComponent<Text>();      
    }

   
    void Update()
    {
        CL_A = Mathf.Lerp(0, 255, count);

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
                textT.color = new Color32(0, 0, 0, 255);
                if (Input.GetKeyDown(KeyCode.JoystickButton0) == true && check.BuuttonCK() == true)
                {
                    StartCoroutine(SceneLoader.LoadSceneAsync("StageSelect", "Prefabs/UI and HUD/Loading Canvas", 3));
                    Debug.Log("osita A");
                }
                break;
            case 2:
                textT.color = new Color32(255, 255, 255, (byte)CL_A);
                textH.color = new Color32(0, 0, 0, 255);
                if (Input.GetKeyDown(KeyCode.JoystickButton0) == true && check.BuuttonCK() == true)
                {
                    StartCoroutine(SceneLoader.LoadSceneAsync("StageSelect", "Prefabs/UI and HUD/Loading Canvas", 3));
                    Debug.Log("osita A");
                }
                break;
        }

      
    }
}
