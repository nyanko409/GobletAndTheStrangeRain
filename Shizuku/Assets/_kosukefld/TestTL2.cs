using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTL2 : MonoBehaviour
{
    bool CK = false;
    public bool CK2()
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
