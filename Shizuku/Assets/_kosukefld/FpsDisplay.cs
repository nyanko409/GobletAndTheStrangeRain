using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsDisplay : MonoBehaviour
{

    
    int frameCount;
    float prevTime;
    float fps;

    
    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
    }
   
    void Update()
    {
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            fps = frameCount / time;
           // Debug.Log(fps);

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        GUILayout.Label(fps.ToString());
    }
}
