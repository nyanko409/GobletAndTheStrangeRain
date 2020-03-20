using UnityEngine;

public class RippleEffectProvider : MonoBehaviour
{
    Color rippleColor;           // color of the ripple
    float rippleSpreadSpeed;     // the spread speed of the ripple


    public void SetColor(Color color) => rippleColor = color;

    public void SetRippleSpreadSpeed(float speed) => rippleSpreadSpeed = speed;

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
            receiver.ApplyEffect(transform.position, rippleColor, rippleSpreadSpeed);
        }
        
        // else check for parent
        else if(parent.CompareTag("RippleReceiver"))
        {
            var receiver = parent.GetComponent<RippleEffectReceiver>();
            if (receiver == null)
                return;

            // apply the effect on receiver
            receiver.ApplyEffect(transform.position, rippleColor, rippleSpreadSpeed);
        }

        Destroy(gameObject);
    }
}
