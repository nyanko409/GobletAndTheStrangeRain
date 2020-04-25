using UnityEngine;
using System.Collections.Generic;

public enum TagCPType
{
    Player, RippleReceiver, RippleProvider, Moveable
}


public class TagCP : MonoBehaviour
{
    public List<TagCPType> tags;


    public void AddTag(TagCPType type)
    {
        tags.Add(type);
    }

    public void RemoveTag(TagCPType type)
    {
        tags.Remove(type);
    }

    public void ClearTag()
    {
        tags.Clear();
    }

    public bool HasTag(TagCPType type)
    {
        return tags.Contains(type);
    }
}
