using UnityEngine;

public class DropDroplet : MonoBehaviour
{
    RippleData? data;
    GameInput action;
    MeshRenderer renderer;


    private void Awake()
    {
        // init actions
        action = new GameInput();
        action.Player.DropDroplet.performed += context => Drop();
    }

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
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

                    renderer.enabled = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        RippleEffectProvider provider;
        if (other.gameObject.TryGetComponent(out provider))
        {
            // copy the ripple data
            RippleData d = new RippleData();
            d.color = provider.RippleColor;
            d.spreadSpeed = provider.RippleSpreadSpeed;
            data = d;

            // change the water color
            renderer.enabled = true;
            renderer.material.SetColor("_BaseColor", d.color);
            renderer.material.SetColor("_RippleColor", d.color);
        }
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
