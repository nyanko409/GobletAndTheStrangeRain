using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GoToTitle : MonoBehaviour
{

    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Space))
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

