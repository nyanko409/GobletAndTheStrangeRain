using UnityEngine;

public class Droplet : MonoBehaviour
{
    float speed;                        // the speed of the droplet
    Vector3 direction = Vector3.down;   // direction the droplet is falling


    public void SetSpeed(float speed) => this.speed = speed;

    public void SetDirection(Vector3 direction) => this.direction = direction;

    void Start()
    {
        Destroy(gameObject, 10F);
    }

    void Update()
    {
        // apply gravity in direction by speed
        transform.position += direction * Time.deltaTime * speed;
    }
}
