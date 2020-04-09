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
        Camera camera = Camera.main;
        
        if(camera.gameObject.transform.position.x >= 44 || camera.gameObject.transform.position.y >= 30)
        {
            camera.gameObject.transform.Translate(new Vector3(0.00f, 0.0f, 0.0f));
        }
        else
        {
            camera.gameObject.transform.Translate(new Vector3(0.01f, 0.01f, 0.00f));
        }


        cam.fieldOfView = view + zoom;

        // 最小値と最大値を決める（自由に変更可能）
        if (cam.fieldOfView < 20f)
        {
            cam.fieldOfView = 20f;
        }

        // 「自分の主観カメラ」を基準に数値を決めてください。
        if (cam.fieldOfView > 60f)
        {
            cam.fieldOfView = 60f;
        }

        // リターンキーを押すと、zoomの数値が減少（ボタンは自由に変更可能）
        if (Input.GetMouseButton(0))
        {
            // どれくらいの速度でzoomを変更させるかも自由です。
            zoom -= 0.1f;
            camera.gameObject.transform.Translate(new Vector3(0.1f, 0.1f, 0.00f));

        } // 右シフトキーを押すと、zoomの数値が増加（ボタンは自由に変更可能）
        else if (Input.GetMouseButton(1))
        {
            zoom += 0.1f;
            camera.gameObject.transform.Translate(new Vector3(-0.1f, -0.1f, 0.00f));
        }
    }
}
