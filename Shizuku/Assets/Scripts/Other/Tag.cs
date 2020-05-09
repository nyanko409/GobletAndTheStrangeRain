using UnityEngine;
using System.Collections.Generic;

public enum TagType
{
    Player, RippleReceiver, RippleProvider,
    Moveable, FreezeRotation, AffectedByWind
}


public class Tag : MonoBehaviour
{
    public List<TagType> tags;


    public void AddTag(TagType type)
    {
        tags.Add(type);
        UpdateValues();
    }

    public void RemoveTag(TagType type)
    {
        tags.Remove(type);
        UpdateValues();
    }

    public void ClearTag()
    {
        tags.Clear();
    }

    public bool HasTag(TagType type)
    {
        return tags.Contains(type);
    }

    private void Start()
    {
        UpdateValues();
    }

    private void UpdateValues()
    {
        // set values depending on selected tags
        if (TryGetComponent(out Rigidbody rb))
        {
            // rigidbody mass
            if (HasTag(TagType.Moveable))
                rb.mass = Mathf.Infinity;

            // rigidbody constraints
            if (HasTag(TagType.Moveable))
                rb.constraints = RigidbodyConstraints.None;
            else if(!HasTag(TagType.Player))
                rb.constraints = RigidbodyConstraints.FreezeAll;

            if (HasTag(TagType.FreezeRotation))
                rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
