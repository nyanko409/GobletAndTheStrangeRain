using UnityEngine;

public class DropDroplet : MonoBehaviour
{
    public float colorTransitionSpeed = 0.1F;

    RippleData? data;
    GameInput action;
    Animator animWater;
    Animator animPlayer;
    MeshRenderer rend;
    Vector3 contactPoint;
    Vector3 contactTransformPos;
    float rippleRadius;
    float maxRadius;
    bool isSpreading;
    bool isDroppable;
    bool dropPressed;


    public bool HasWater()
    {
        return data.HasValue;
    }

    public bool CanDrop()
    {
        return isDroppable;
    }

    public Color GetColor()
    {
        return data.HasValue ? data.Value.color : default;
    }


    private void Awake()
    {
        // init actions
        action = new GameInput();
        action.Player.DropDroplet.started += context => dropPressed = true;
        action.Player.DropDroplet.canceled += context => dropPressed = false;
    }

    private void Start()
    {
        animWater = GetComponent<Animator>();
        animPlayer = GameObject.FindWithTag("Player").GetComponent<Animator>();
        
        rend = GetComponent<MeshRenderer>();
    }

    private void Drop()
    {
        // raycast down and apply ripple effect if receiver is found
        if(data.HasValue && !isSpreading)
        {
            if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1000, LayerMask.GetMask("Room", "Obstacle")))
            {
                if(hit.transform.gameObject.TryGetComponent(out RippleEffectReceiver receiver))
                {
                    isDroppable = true;

                    if (!dropPressed)
                        return;

                    receiver.ApplyEffect(hit.point, data.Value.color, data.Value.spreadSpeed);
                    data = null;

                    animWater.SetTrigger("Empty Water");
                    animPlayer.SetTrigger("Spill");

                    return;
                }
            }
        }

        isDroppable = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        RippleEffectProvider provider;
        if (other.gameObject.TryGetComponent(out provider))
        {
            if (!data.HasValue)
            {
                // play animation if water is not filled
                animWater.SetTrigger("Fill Water");
                rend.material.SetColor("_BaseColor", provider.RippleColor);
            }
            else if(!isSpreading)
            {
                // else start color transition
                var offsetPoint = other.transform.position;
                offsetPoint.y -= other.transform.position.y - transform.position.y;

                maxRadius = GetFarthestVertex(offsetPoint);
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
            rippleRadius += colorTransitionSpeed * Time.deltaTime;
            rend.material.SetFloat("_RippleRadius", rippleRadius);

            // reset the values if water is transitioned to the new color
            if (rippleRadius >= maxRadius)
            {
                isSpreading = false;
                rippleRadius = -1;

                rend.material.SetFloat("_RippleRadius", rippleRadius);
                rend.material.SetColor("_BaseColor", data.Value.color);
            }
        }
    }

    float GetFarthestVertex(Vector3 origin)
    {
        // get every vertex from mesh (enable read/write in mesh settings!)
        Vector3[] vertices = GetComponent<MeshFilter>().sharedMesh.vertices;

        // get the local to world transformation matrix
        Matrix4x4 localToWorld = transform.localToWorldMatrix;

        // offset each vertex to world position and
        // calculate the distance between contact point and vertex position
        float[] dist = new float[vertices.Length];
        for (int i = 0; i < vertices.Length; ++i)
        {
            vertices[i] = localToWorld.MultiplyPoint3x4(vertices[i]);
            dist[i] = Mathf.Abs(Vector3.Distance(vertices[i], origin));
        }

        // sort the array and return the farthest vertex position
        System.Array.Sort(dist);
        return dist[dist.Length - 1];
    }

    private void Update()
    {
        UpdateShader();

        Drop();
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
