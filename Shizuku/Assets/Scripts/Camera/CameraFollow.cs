using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 15F;


    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, smoothSpeed * Time.deltaTime);
    }
}
