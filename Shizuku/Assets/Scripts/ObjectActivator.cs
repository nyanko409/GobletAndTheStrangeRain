using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [Range(-.5F, .5F)] public float rangeOffset;        // offset to the range when this object should appear/disappear
    [SerializeField] RippleEffectReceiver receiver;     // receiver object to check the color from

    Material mat;                                       // reference to the attached material
    MeshRenderer rend;                                  // reference to the attached renderer
    Collider col;                                       // reference to the attached collider
    Color receiverColor;                                // current color the object is standing on


    void Start()
    {
        mat = GetComponent<Renderer>().material;
        rend = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
    }

    void Update()
    {
        // get the nearest receiver color
        receiverColor = GetNearestReceiverColor();

        // disable or enable the object depending on the nearest receiver color
        if(mat.GetColor("_BaseColor").IsEqualTo(receiverColor))
        {
            rend.enabled = false;
            col.enabled = false;
        }
        else
        {
            rend.enabled = true;
            col.enabled = true;
        }
    }

    Color GetNearestReceiverColor()
    {
        var ripples = receiver.GetRippleDatas();

        // loop from back
        for (int i = ripples.Length - 1; i >= 0; --i)
        {
            // check the color of the nearest receiver point
            if (ripples[i].isSpreading &&
                Mathf.Abs(Vector3.Distance(ripples[i].position, transform.position))
                <= ripples[i].radius - rangeOffset)
            {
                return ripples[i].color;
            }
        }

        return receiver.GetBackgroundColor();
    }
}
