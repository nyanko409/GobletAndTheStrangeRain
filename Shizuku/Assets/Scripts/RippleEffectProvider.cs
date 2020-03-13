using UnityEngine;

public class RippleEffectProvider : MonoBehaviour
{
    Color rippleColor = Color.blue;
    float rippleSpreadSpeed = 0.2F;


    public void SetColor(Color color) => rippleColor = color;

    public void SetRippleSpreadSpeed(float speed) => rippleSpreadSpeed = speed;

    void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
        if(parent.CompareTag("RippleReceiver"))
        {
            var receiver = parent.GetComponent<RippleEffectReceiver>();

            if (receiver == null)
                return;

            receiver.ApplyEffect(transform.position, rippleColor, rippleSpreadSpeed);
        }
    }
}
