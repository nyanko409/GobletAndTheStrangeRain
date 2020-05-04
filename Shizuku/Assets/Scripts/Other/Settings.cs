using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameSettings settings;


    private void Awake()
    {
        // return if no preset is set
        if (!settings) return;

        Application.targetFrameRate = settings.targetFPS;
    }
}
