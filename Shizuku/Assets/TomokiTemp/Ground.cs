using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    GameObject ground;

    // todo：強引な方法を使っているので修正
    int groundColor;

    // Start is called before the first frame update
    void Start()
    {
        groundColor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキー押下で色を赤青交互に切り替える
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (groundColor == 0) {
                groundColor = 1;
                GetComponent<Renderer>().material.color = Color.blue;
            }

            if (groundColor == 1) {
                groundColor = 0;
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
