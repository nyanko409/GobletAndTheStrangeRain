using UnityEngine;
using System.Collections.Generic;

public enum TagType
{
    Player, RippleReceiver, RippleProvider, Moveable
}


public class Tag : MonoBehaviour
{
    public List<TagType> tags;


    public void AddTag(TagType type)
    {
        tags.Add(type);
    }

    public void RemoveTag(TagType type)
    {
        tags.Remove(type);
    }

    public void ClearTag()
    {
        tags.Clear();
    }

    public bool HasTag(TagType type)
    {
        return tags.Contains(type);
    }
}
