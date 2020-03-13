using UnityEngine;

public class RippleEffectReceiver : MonoBehaviour
{
    Material material;
    float rippleSpreadSpeed;
    float rippleRadius = 0;
    bool isSpreading = false;


    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (isSpreading)
        {
            rippleRadius += rippleSpreadSpeed * Time.deltaTime;
            material.SetFloat("_RippleRadius", rippleRadius);
        }
    }

    public void ApplyEffect(Vector3 contactPoint, Color rippleColor, float spreadSpeed)
    {
        material.SetVector("_RippleLocation", contactPoint);
        material.SetColor("_RippleColor", rippleColor);

        rippleSpreadSpeed = spreadSpeed;
        isSpreading = true;
    }
}
