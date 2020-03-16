using UnityEngine;

public class Droplet : MonoBehaviour
{
    float speed = 0.5F;
    Vector3 direction = Vector3.down;


    public void SetSpeed(float speed) => this.speed = speed;

    public void SetDirection(Vector3 direction) => this.direction = direction;

    void Update()
    {
        // apply gravity in direction by speed
        transform.position += direction * Time.deltaTime * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, 10F);
        if (other.CompareTag("RippleReceiver"))
            Destroy(gameObject, 1F);
    }
}
