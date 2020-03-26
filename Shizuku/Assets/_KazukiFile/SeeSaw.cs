using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSaw : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;

    //　床に与える力
    [SerializeField]
    private float power = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //　他のコライダと接触した時
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        //　確認の為レイを視覚的に見えるようにする
        Debug.DrawLine(transform.position + Vector3.up * 0.1f, transform.position + Vector3.up * 0.1f + Vector3.down * 0.2f, Color.red);

        //　rayPositionから下にレイを飛ばし、Blockレイヤーに当たっていたら力を加える
        if (Physics.Linecast(transform.position + Vector3.up * 0.1f, transform.position + Vector3.up * 0.1f + Vector3.down * 0.2f, LayerMask.GetMask("Block")))
        {
            col.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.down * power, transform.position, ForceMode.Force);
        }
    }
}
