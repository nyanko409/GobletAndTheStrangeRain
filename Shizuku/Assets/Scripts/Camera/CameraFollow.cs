using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 15F;


    private void LateUpdate()
    {
        if(Physics.Raycast(transform.position, -transform.forward, out RaycastHit hit, 10))
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smoothSpeed * Time.deltaTime);

        }
        else
            transform.position = Vector3.Lerp(transform.position, target.position, smoothSpeed * Time.deltaTime);
    }
}
