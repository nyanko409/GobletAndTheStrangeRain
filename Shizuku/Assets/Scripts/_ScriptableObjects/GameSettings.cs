using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    public int targetFPS;
}
