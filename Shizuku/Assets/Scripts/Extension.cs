using UnityEngine;

public static class Extension
{
    public static bool IsEqualTo(this Color my, Color other)
    {
        return my.r == other.r && my.g == other.g && my.b == other.b;
    }
}
