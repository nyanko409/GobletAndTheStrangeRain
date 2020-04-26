using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public TitleUI check;

    void Start()
    {
        
    }

   
    void Update()
    {
       if( Input.GetKeyDown(KeyCode.JoystickButton0) == true && check.BuuttonCK()==true)
        {
            StartCoroutine(SceneLoader.LoadSceneAsync("StageSelect", "Prefabs/UI and HUD/Loading Canvas", 3));
            Debug.Log("osita A");
        }
    }
}
