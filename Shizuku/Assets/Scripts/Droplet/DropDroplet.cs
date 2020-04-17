using UnityEngine;

public class DropDroplet : MonoBehaviour
{
    RippleData? data;
    GameInput action;


    private void Awake()
    {
        // init actions
        action = new GameInput();
        action.Player.DropDroplet.performed += context => Drop();
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
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        RippleEffectProvider prov;
        other.gameObject.TryGetComponent(out prov);
        if(prov)
        {
            RippleData d = new RippleData();
            d.color = prov.RippleColor;
            d.spreadSpeed = prov.RippleSpreadSpeed;
            data = d;
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
