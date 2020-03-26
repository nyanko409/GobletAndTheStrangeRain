using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [Range(-.5F, .5F)] public float rangeOffset;        // offset to the range when this object should appear/disappear
    [SerializeField] RippleEffectReceiver receiver;     // receiver object to check the color from
    public float alphaSpeed = 0.5F;

    Material mat;                                       // reference to the attached material
    Collider col;                                       // reference to the attached collider
    Color receiverColor;                                // current color the object is standing on
    float curAlpha;


    void Start()
    {
        mat = GetComponent<Renderer>().material;
        col = GetComponent<Collider>();
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
            curAlpha = Mathf.Clamp(curAlpha, 0.01F, 1);
            mat.SetFloat("_Alpha", curAlpha);
        }
        else
        {
            col.enabled = true;
            curAlpha += alphaSpeed * Time.deltaTime;
            curAlpha = Mathf.Clamp01(curAlpha);
            mat.SetFloat("_Alpha", curAlpha);
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
}
