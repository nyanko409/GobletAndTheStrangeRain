using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public float force = 10;

    private List<Rigidbody> rigidbodies;


    private void Start()
    {
        rigidbodies = new List<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // move all rigidbodies inside wind area
        foreach(Rigidbody rb in rigidbodies)
        {
            rb.MovePosition(rb.position + direction * force * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // return if the collider does not get affected by wind
        if (!(other.TryGetComponent(out Tag tag) && tag.HasTag(TagType.AffectedByWind)))
            return;

        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);
        rigidbodies.Add(other.gameObject.GetComponent<Rigidbody>());
    }

    private void OnTriggerExit(Collider other)
    {
        // return if the collider does not get affected by wind
        if (!(other.TryGetComponent(out Tag tag) && tag.HasTag(TagType.AffectedByWind)))
            return;

        ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);
        rigidbodies.Remove(other.gameObject.GetComponent<Rigidbody>());
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }
}
