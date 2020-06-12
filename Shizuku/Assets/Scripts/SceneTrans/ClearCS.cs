using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearCS : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            FadeManager.FadeOut("Goal");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn();
    }
}
