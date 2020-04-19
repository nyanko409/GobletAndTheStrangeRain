using UnityEngine;

public class DropDroplet : MonoBehaviour
{
    public float rippleSpreadSpeed = 0.1F;

    RippleData? data;
    GameInput action;
    Animator anim;
    MeshRenderer rend;
    Vector3 contactPoint;
    Vector3 contactTransformPos;
    float rippleRadius;
    bool isSpreading;


    private void Awake()
    {
        // init actions
        action = new GameInput();
        action.Player.DropDroplet.performed += context => Drop();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rend = GetComponent<MeshRenderer>();
    }

    private void Drop()
    {
        // raycast down and apply ripple effect if receiver is found
        if(data.HasValue)
        {
            if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 10))
            {
                RippleEffectReceiver receiver = hit.transform.GetComponentInParent<RippleEffectReceiver>();
                if(receiver || hit.transform.gameObject.TryGetComponent(out receiver))
                {
                    receiver.ApplyEffect(hit.point, data.Value.color, data.Value.spreadSpeed);
                    data = null;

                    anim.SetTrigger("Empty Water");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        RippleEffectProvider provider;
        if (other.gameObject.TryGetComponent(out provider))
        {
            if (!data.HasValue)
            {
                // play animation if water is not filled
                anim.SetTrigger("Fill Water");
                rend.material.SetColor("_BaseColor", provider.RippleColor);
            }
            else if(!isSpreading)
            {
                // else start color transition
                var offsetPoint = other.transform.position;
                offsetPoint.y -= other.transform.position.y - transform.position.y;

                InitColorTransition(provider, offsetPoint);
            }

            // copy the ripple data
            RippleData d = new RippleData();
            d.color = provider.RippleColor;
            d.spreadSpeed = provider.RippleSpreadSpeed;
            data = d;
        }
    }

    private void InitColorTransition(RippleEffectProvider provider, Vector3 contactPoint)
    {
        rippleRadius = 0;
        isSpreading = true;
        this.contactPoint = contactPoint;
        contactTransformPos = transform.position;

        rend.material.SetColor("_RippleColor", provider.RippleColor);
        rend.material.SetVector("_RippleContactPoint", contactPoint);
        rend.material.SetFloat("_RippleRadius", rippleRadius);
    }

    private void UpdateShader()
    {
        if (isSpreading)
        {
            // adjust the contact point when player moves
            var diff = transform.position - contactTransformPos;
            contactPoint += diff;

            contactTransformPos = transform.position;

            rend.material.SetVector("_RippleContactPoint", contactPoint);

            // update the ripple radius
            rippleRadius += rippleSpreadSpeed * Time.deltaTime;
            rend.material.SetFloat("_RippleRadius", rippleRadius);
            if (rippleRadius >= 2.5F)
            {
                isSpreading = false;
                rend.material.SetColor("_BaseColor", data.Value.color);
            }
        }
    }

    private void Update()
    {
        UpdateShader();   
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
}
