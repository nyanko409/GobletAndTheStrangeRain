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
        Transform parent = other.transform.parent;

        // call receiver method if tag did match
        if(parent.CompareTag("RippleReceiver"))
        {
            // return if receiver component is not found
            var receiver = parent.GetComponent<RippleEffectReceiver>();
            if (receiver == null)
                return;

            // apply the effect on receiver
            receiver.ApplyEffect(transform.position + direction * distFactor, rippleColor, rippleSpreadSpeed);
        }

        Destroy(gameObject);
    }
}
