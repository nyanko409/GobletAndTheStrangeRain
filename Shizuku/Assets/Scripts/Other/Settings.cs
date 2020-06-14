using UnityEngine;

public class Settings : Singleton<Settings>
{
    public GameSettings settings;


    protected override void Awake()
    {
        base.Awake();

        // return if no preset is set
        if (!settings) return;

        Application.targetFrameRate = settings.targetFPS;
    }
}
