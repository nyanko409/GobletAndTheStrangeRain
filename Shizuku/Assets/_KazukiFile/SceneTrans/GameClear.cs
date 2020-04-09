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
    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
