using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public Transform transitionPoint;               // the pivot point to change the activation state
    public Texture texture;
    public float disabledScaleRatio;             
    public float rangeOffset;                       // offset to the range when this object should appear/disappear
    public float alphaSpeed = 0.5F;                 // the alpha fading speed
    public float minAlpha = 0.05F;
    public Shader opaqueShader;                     // render with this shader if it is visible
    public Shader transparentShader;                // render with this shader if it is transparent

    private RippleEffectReceiver receiver;          // receiver object to check the color from
    private Vector3 startingScale;
    private bool scalingApplied;
    private Tag tag;
    private bool isOverlapping;
    private MeshRenderer rend;                      // reference to the attached mesh renderer
    private Material mat;                           // reference to the attached material
    private Collider col;                           // reference to the attached collider
    private Rigidbody rb;                           // reference to the attached rigidbody
    private Color receiverColor;                    // current color the object is standing on
    private float curAlpha;


    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        mat = GetComponent<Renderer>().material;
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        tag = GetComponent<Tag>();

        if (!transitionPoint)
            transitionPoint = transform;

        startingScale = transform.localScale;
        mat.shader = opaqueShader;
        rb.mass = float.PositiveInfinity;
        isOverlapping = false;
        curAlpha = 1;

        mat.SetTexture("_MainTexture", texture);

        UpdateRippleEffectReceiver();
    }

    void Update()
    {
        if (!tag.HasTag(TagType.RippleReceiver))
            return;

        // get the nearest receiver color
        UpdateRippleEffectReceiver();
        receiverColor = GetNearestReceiverColor();

        // disable or enable the object depending on the nearest receiver color
        if(mat.GetColor("_BaseColor").IsEqualTo(receiverColor))
        {
            if (!col.isTrigger)
            {
                mat.shader = transparentShader;
                rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

                col.isTrigger = true;
                rb.isKinematic = true;
                isOverlapping = false;
                gameObject.layer = LayerMask.NameToLayer("Obstacle Disabled");
            }

            if (curAlpha > minAlpha)
            {
                curAlpha -= alphaSpeed * Time.deltaTime;
                curAlpha = Mathf.Clamp(curAlpha, minAlpha, 1);
                mat.SetFloat("_Alpha", curAlpha);
            }
            else if(!scalingApplied)
            {
                transform.localScale *= disabledScaleRatio;
                scalingApplied = true;
            }
        }
        else
        {
            // enable if it is not overlapping
            if (col.isTrigger && !isOverlapping)
            {
                col.isTrigger = false;
                rb.isKinematic = false;
                transform.localScale = startingScale;
                scalingApplied = false;
                gameObject.layer = LayerMask.NameToLayer("Obstacle");
            }

            if (!col.isTrigger)
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

        // get the color this object is standing on
        int layer = -1, index = -1;
        for (int i = 0; i < ripples.Length; ++i)
        {
            if (ripples[i].isSpreading &&
                Vector3.Distance(ripples[i].position, transitionPoint.position)
                <= ripples[i].radius - rangeOffset)
            {
                if (ripples[i].layer > layer)
                {
                    layer = ripples[i].layer;
                    index = i;
                }
            }

        }

        return index != -1 ? ripples[index].color : receiver.GetBackgroundColor();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!col.isTrigger)
            return;

        isOverlapping = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isOverlapping = false;
    }
}
