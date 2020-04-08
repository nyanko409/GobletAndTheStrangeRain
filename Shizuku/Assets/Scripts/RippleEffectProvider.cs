using UnityEngine;

public class RippleEffectProvider : MonoBehaviour
{
    public Color RippleColor { get; set; }         // color of the ripple
    public float RippleSpreadSpeed { get; set; }   // the spread speed of the ripple


    // constructor
    public RippleEffectProvider() {}

    // copy constructor
    public RippleEffectProvider(RippleEffectProvider provider)
    {
        RippleColor = provider.RippleColor;
        RippleSpreadSpeed = provider.RippleSpreadSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        // get the parent
        Transform parent = other.transform.parent;

        // if parent is null check the collided object
        if (!parent)
        {
            if (other.transform.GetComponent<Tag>().HasTag(TagType.RippleReceiver))
            {
                var receiver = other.GetComponent<RippleEffectReceiver>();

                // apply the effect on receiver
                if (receiver)
                    receiver.ApplyEffect(transform.position, RippleColor, RippleSpreadSpeed);
            }
        }

        // else check for parent
        else if (parent.GetComponent<Tag>().HasTag(TagType.RippleReceiver))
        {
            var receiver = parent.GetComponent<RippleEffectReceiver>();

            // apply the effect on receiver
            if (receiver)
                receiver.ApplyEffect(transform.position, RippleColor, RippleSpreadSpeed);
        }

        Destroy(gameObject);
    }
}
