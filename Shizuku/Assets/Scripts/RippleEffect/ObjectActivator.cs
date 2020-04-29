using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public float rangeOffset;                           // offset to the range when this object should appear/disappear
    public float alphaSpeed = 0.5F;                     // the alpha fading speed
    public float minAlpha = 0.05F;
    public Shader opaqueShader;                         // render with this shader if it is visible
    public Shader transparentShader;                    // render with this shader if it is transparent

    RippleEffectReceiver receiver;                      // receiver object to check the color from
    MeshRenderer rend;                                  // reference to the attached mesh renderer
    Material mat;                                       // reference to the attached material
    Collider col;                                       // reference to the attached collider
    Rigidbody rb;                                       // reference to the attached rigidbody
    Color receiverColor;                                // current color the object is standing on
    float curAlpha;


    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        mat = GetComponent<Renderer>().material;
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

        mat.shader = opaqueShader;
        rb.mass = float.PositiveInfinity;
        curAlpha = 1;

        UpdateRippleEffectReceiver();
    }

    void Update()
    {
        // get the nearest receiver color
        UpdateRippleEffectReceiver();
        receiverColor = GetNearestReceiverColor();

        // disable or enable the object depending on the nearest receiver color
        if(mat.GetColor("_BaseColor").IsEqualTo(receiverColor))
        {
            if (mat.shader != transparentShader)
            {
                mat.shader = transparentShader;
                rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            }

            if (curAlpha > minAlpha)
            {
                col.enabled = false;
                rb.isKinematic = true;

                curAlpha -= alphaSpeed * Time.deltaTime;
                curAlpha = Mathf.Clamp(curAlpha, minAlpha, 1);
                mat.SetFloat("_Alpha", curAlpha);
            }
        }
        else
        {
            // enable if it is not overlapping
            if (!col.enabled && !CheckOverlap())
            {
                col.enabled = true;
                rb.isKinematic = false;
            }

            if (col.enabled)
            {
                curAlpha += alphaSpeed * Time.deltaTime;
                curAlpha = Mathf.Clamp01(curAlpha);
                mat.SetFloat("_Alpha", curAlpha);

                if (mat.shader != opaqueShader && curAlpha == 1)
                {
                    mat.shader = opaqueShader;
                    rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                }
            }
        }
    }

    private void UpdateRippleEffectReceiver()
    {
        // update the receiver to get the color from when transform has moved
        if (transform.hasChanged)
        {
            transform.hasChanged = false;
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1000, LayerMask.GetMask("Room")))
            {
                receiver = hit.transform.GetComponent<RippleEffectReceiver>();
            }
        }
    }

    private Color GetNearestReceiverColor()
    {
        // get ripple data and sort it by layer
        var ripples = receiver.GetRippleDatas();
        System.Array.Sort(ripples, CompareRippleLayer);

        // loop from back
        for (int i = ripples.Length - 1; i >= 0; --i)
        {
            // check the color of the nearest receiver point
            if (ripples[i].isSpreading &&
                Vector3.Distance(ripples[i].position, transform.position)
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
            // ignore self and trigger colliders
            if(col.name != name && !col.isTrigger && col.gameObject.layer != LayerMask.NameToLayer("Room"))
                return true;
        }

        // not overlapping with anything
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale - new Vector3(0.1F, 0.1F, 0.1F));
    }
}
