using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Posenext : MonoBehaviour
{

    public PauseSelect data;
    public Image res;
    public Image theck;
    public Image map;
    public float colorspeed = 0.05f;
    float CL_A = 0;
    float count = 0;
    int colorcount = 2;
    int poseR = 0;

    bool Restart = false;
    bool checkpoint = false;

    public int PoseRCK()
    {
        return poseR;
    }

    public bool RestartCK()
    {
        return Restart;
    }

    public bool CheckpointCK()
    {
        return checkpoint;
    }

    void Start()
    {
        res.color = new Color32(0, 0, 0, 255);
        theck.color = new Color32(0, 0, 0, 255);
        map.color = new Color32(0, 0, 0, 255);
    }


    void Update()
    {
        CL_A = Mathf.Lerp(255, 0, count);
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
        switch (data.nextCK())
        {
            case 1:
                res.color = new Color32(0, 0, 0, (byte)CL_A);
                theck.color = new Color32(0, 0, 0, 255);
                map.color = new Color32(0, 0, 0, 255);
                if (Input.GetKeyDown(KeyCode.JoystickButton0) == true && data.BCK() == true)
                {
                    poseR = 1;
                    Restart = true;
                    Debug.Log("Restart");
                    Debug.Log(Restart);
                }

                    break;
            case 2:
                res.color = new Color32(0, 0, 0, 255);
                theck.color = new Color32(0, 0, 0, (byte)CL_A);
                map.color = new Color32(0, 0, 0, 255);
                if (Input.GetKeyDown(KeyCode.JoystickButton0) == true && data.BCK() == true)
                {
                    poseR = 1;
                    checkpoint = true;
                    Debug.Log("checkpoint");
                    Debug.Log(checkpoint);
                }
                break;
            case 3:
                res.color = new Color32(0, 0, 0, 255);
                theck.color = new Color32(0, 0, 0, 255);
                map.color = new Color32(0, 0, 0, (byte)CL_A);
                if (Input.GetKeyDown(KeyCode.JoystickButton0) == true && data.BCK() == true)
                {
                    StartCoroutine(SceneLoader.LoadSceneAsync("StageSelect", "Prefabs/UI and HUD/Loading Canvas", 3));
                    Debug.Log("osita A");
                }
                break;
               

        }
        if(data.poseED()==true)
        {
            poseR = 0;
            Restart = false;
            Debug.Log(Restart);
        }
        if(data.poseED()==true)
        {
            poseR = 0;
            checkpoint = false;
            Debug.Log(checkpoint);
        }
    }
}
