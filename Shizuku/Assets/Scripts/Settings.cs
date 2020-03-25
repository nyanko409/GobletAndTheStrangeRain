using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameSettings settings;


    private void Awake()
    {
        if (!settings) return;

        Application.targetFrameRate = settings.targetFPS;
    }
}
