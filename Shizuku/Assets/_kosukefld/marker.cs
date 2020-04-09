using UnityEngine;
using System.Collections;

public class marker : MonoBehaviour
{
    public float lifetime;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}