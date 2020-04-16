using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera cam;
    private float zoom;
    private float view;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        view = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
      
        cam.fieldOfView = view + zoom;

        // 最小値と最大値
        if (cam.fieldOfView < 20f)
        {
            cam.fieldOfView = 20f;
        }

        if (cam.fieldOfView > 60f)
        {
            cam.fieldOfView = 60f;
        }

        // ズームイン
        if (Input.GetMouseButton(0))
        {
            
            zoom -= 0.18f;
            
            
            if (GetComponent<Camera>().gameObject.transform.position.x >= 22 || GetComponent<Camera>().gameObject.transform.position.y >= 15)
            {
                GetComponent<Camera>().gameObject.transform.Translate(new Vector3(0.00f, 0.0f, 0.0f));
            }
            else
            {
                GetComponent<Camera>().gameObject.transform.Translate(new Vector3(0.09f, 0.05f, 0.00f));
            }

        } // ズームアウト
        else if (Input.GetMouseButton(1))
        {
            zoom += 0.1f;
        }   
    }
}
