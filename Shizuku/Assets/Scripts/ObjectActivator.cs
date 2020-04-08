using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public float rangeOffset;                           // offset to the range when this object should appear/disappear
    public RippleEffectReceiver receiver;               // receiver object to check the color from
    public float alphaSpeed = 0.5F;                     // the alpha fading speed

    Material mat;                                       // reference to the attached material
    Collider col;                                       // reference to the attached collider
    Rigidbody rb;                                       // reference to the attached rigidbody
    Color receiverColor;                                // current color the object is standing on
    float curAlpha;


    void Start()
    {
        mat = GetComponent<Renderer>().material;
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

        rb.mass = float.PositiveInfinity;
        curAlpha = 1;
    }

    void Update()
    {
        // get the nearest receiver color
        receiverColor = GetNearestReceiverColor();

        // disable or enable the object depending on the nearest receiver color
        if(mat.GetColor("_BaseColor").IsEqualTo(receiverColor))
        {
            col.enabled = false;
            curAlpha -= alphaSpeed * Time.deltaTime;
            curAlpha = Mathf.Clamp(curAlpha, 0.05F, 1);
            mat.SetFloat("_Alpha", curAlpha);
            rb.isKinematic = true;
        }
        // enable if it is not overlapping
        else if(!CheckOverlap())
        {
            col.enabled = true;
            curAlpha += alphaSpeed * Time.deltaTime;
            curAlpha = Mathf.Clamp01(curAlpha);
            mat.SetFloat("_Alpha", curAlpha);
            rb.isKinematic = false;
        }
    }

    Color GetNearestReceiverColor()
    {
        // get ripple data and sort it by layer
        var ripples = receiver.GetRippleDatas();
        System.Array.Sort(ripples, CompareRippleLayer);

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

    private int CompareRippleLayer(RippleData a, RippleData b)
    {
        return a.layer.CompareTo(b.layer);
    }

    // returns true if overlapping with some object
    private bool CheckOverlap()
    {
        // get all colliders inside
        Collider[] colliders = Physics.OverlapBox(transform.position,
            (transform.localScale / 2) - new Vector3(0.1F, 0.1F, 0.1F), transform.rotation);
        foreach(Collider col in colliders)
        {
            // ignore self collision
            if(col.name != name)
                return true;
        }

        // not overlapping with anything
        return false;
    }
}
