using UnityEngine;

public class Droplet : MonoBehaviour
{
    public Vector3 Direction { private get; set; }      // the direction the droplet is falling
    public float Speed { private get; set; }            // the speed of the droplet
    public AudioClip dropletSound;


    void Start()
    {
        Destroy(gameObject, 10F);
    }

    void Update()
    {
        // apply gravity in direction by speed
        transform.position += Direction * Time.deltaTime * Speed;
    }

    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(dropletSound, transform.position);
    }
}
