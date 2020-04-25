﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            Debug.Log(hit.collider.gameObject.transform.position);
        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("hit");
        }
    }
}
