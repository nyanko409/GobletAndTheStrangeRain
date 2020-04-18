using UnityEngine;

public class DropDroplet : MonoBehaviour
{
    public GameObject water;

    RippleData? data;
    GameInput action;


    private void Awake()
    {
        // init actions
        action = new GameInput();
        action.Player.DropDroplet.performed += context => Drop();
    }

    private void Start()
    {
        water.SetActive(false);
    }

    private void Drop()
    {
        // raycast down and apply ripple effect if receiver is found
        if(data.HasValue)
        {
            if(Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 10))
            {
                RippleEffectReceiver receiver = hit.transform.GetComponentInParent<RippleEffectReceiver>();
                if(receiver || hit.transform.gameObject.TryGetComponent(out receiver))
                {
                    receiver.ApplyEffect(hit.point, data.Value.color, data.Value.spreadSpeed);
                    data = null;

                    water.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        RippleEffectProvider provider;
        if (other.gameObject.TryGetComponent(out provider))
        {
            // copy the ripple data to local variable
            RippleData d = new RippleData();
            d.color = provider.RippleColor;
            d.spreadSpeed = provider.RippleSpreadSpeed;
            data = d;

            // change the water color
            water.SetActive(true);
            water.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", d.color);
            water.GetComponent<MeshRenderer>().material.SetColor("_RippleColor", d.color);
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
