using UnityEngine;

[CreateAssetMenu(fileName = "Stage", menuName = "ScriptableObject/Stage", order = 2)]
public class Stage : ScriptableObject
{
    public string sceneName;
    public string stageName;
    public bool isLocked;
}
