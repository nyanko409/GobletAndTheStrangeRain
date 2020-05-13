using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float yHeightOffset = 1;
    public float smoothSpeed = 15F;


    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position, target.position + new Vector3(0, yHeightOffset, 0), smoothSpeed * Time.deltaTime);
    }
}
