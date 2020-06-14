using UnityEngine;

public class GoToTitle : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Space))
        {
            FadeManager.FadeOut("Title");
        }
    }

        // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn();
    }

}

