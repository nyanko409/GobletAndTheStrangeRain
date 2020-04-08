using UnityEngine;

public class GameClear : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Tag>().HasTag(TagType.Player))
        {
            FadeManager.FadeOut(1);
        }
    }
}
