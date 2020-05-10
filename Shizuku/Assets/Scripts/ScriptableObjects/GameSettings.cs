using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    public int targetFPS;

    [Range(0, 1)] public float masterVolume;
    [Range(0, 1)] public float bgmVolume;
    [Range(0, 1)] public float seVolume;
}
