using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public float pressHeight = 0.2F;
    public UnityEvent pressEvent;
    public UnityEvent releaseEvent;

    private static AudioSource switchSource;
    private Vector3 startPos;
    private int overlap;


    public bool IsPressed()
    {
        return overlap != 0;
    }


    private void Start()
    {
        if(!switchSource)
            switchSource = GameObject.FindGameObjectWithTag("AudioManager").
                GetComponent<AudioManager>().GetAudioSourceByType(AudioManager.AudioType.SE_Switch);

        startPos = transform.position;
        overlap = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        // only trigger with tag
        if (other.TryGetComponent(out Tag tag) && tag.HasTag(TagType.ToggleButton))
        {
            ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);

            overlap++;

            if (overlap == 1)
            {
                pressEvent.Invoke();
                AudioSource.PlayClipAtPoint(switchSource.clip, transform.position, switchSource.volume);
            }

            transform.position = startPos - new Vector3(0, pressHeight, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Tag tag) && tag.HasTag(TagType.ToggleButton))
        {
            ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);

            overlap--;

            if (overlap == 0)
            {
                transform.position = startPos;
                releaseEvent.Invoke();
                AudioSource.PlayClipAtPoint(switchSource.clip, transform.position, switchSource.volume);
            }
        }
    }
}
