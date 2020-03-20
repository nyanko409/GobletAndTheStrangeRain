using UnityEngine;

public class RippleEffectProvider : MonoBehaviour
{
    float distFactor = .2F;      // offset in addition to the contact point for better looking blending
    Color rippleColor;           // color of the ripple
    float rippleSpreadSpeed;     // the spread speed of the ripple
    Vector3 direction;           // direction the provider is moving, needed for factor offset


    public void SetColor(Color color) => rippleColor = color;

    public void SetRippleSpreadSpeed(float speed) => rippleSpreadSpeed = speed;

    public void SetDirection(Vector3 direction) => this.direction = direction;

    void OnTriggerEnter(Collider other)
    {
        // get the parent
        Transform parent = other.transform.parent;

        // if parent is null check the collided object
        if(!parent && other.transform.CompareTag("RippleReceiver"))
        {
            var receiver = other.GetComponent<RippleEffectReceiver>();
            if (receiver == null)
                return;

            // apply the effect on receiver
            receiver.ApplyEffect(transform.position + direction * distFactor, rippleColor, rippleSpreadSpeed);
        }
        
        // else check for parent
        if(parent.CompareTag("RippleReceiver"))
        {
            var receiver = parent.GetComponent<RippleEffectReceiver>();
            if (receiver == null)
                return;

            // apply the effect on receiver
            receiver.ApplyEffect(transform.position + direction * distFactor, rippleColor, rippleSpreadSpeed);
        }

        Destroy(gameObject);
    }
}
