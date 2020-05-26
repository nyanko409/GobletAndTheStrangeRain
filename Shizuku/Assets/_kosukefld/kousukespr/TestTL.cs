using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTL : MonoBehaviour
{
    bool CK = false;
    public bool CK1()
    {
        return CK;
    }
 
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CK = true;
        }
    }
}
