using UnityEngine;

public class RippleEffectProviderCP : MonoBehaviour
{
    public Color RippleColor { get; set; }         // color of the ripple
    public float RippleSpreadSpeed { get; set; }   // the spread speed of the ripple


    // constructor
    public RippleEffectProviderCP() { }

    // copy constructor
    public RippleEffectProviderCP(RippleEffectProviderCP provider)
    {
        RippleColor = provider.RippleColor;
        RippleSpreadSpeed = provider.RippleSpreadSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        RippleEffectReceiver receiver;

        // find the receiver on collided object and apply the effect
        if (other.transform.TryGetComponent(out receiver) ||
           (other.transform.parent && other.transform.parent.TryGetComponent(out receiver)))
        {
            receiver.ApplyEffect(transform.position, RippleColor, RippleSpreadSpeed);
        }

        Destroy(gameObject);
    }
}
