using UnityEngine;

public class RippleEffectProvider : MonoBehaviour
{
    Color rippleColor = Color.blue;
    float rippleSpreadSpeed;
    Vector3 direction = Vector3.down;
    float distFactor = .2F;


    public void SetColor(Color color) => rippleColor = color;

    public void SetRippleSpreadSpeed(float speed) => rippleSpreadSpeed = speed;

    public void SetDirection(Vector3 direction) => this.direction = direction;

    void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
        if(parent.CompareTag("RippleReceiver"))
        {
            var receiver = parent.GetComponent<RippleEffectReceiver>();

            if (receiver == null)
                return;

            receiver.ApplyEffect(transform.position + direction * distFactor, rippleColor, rippleSpreadSpeed);
        }
    }
}
