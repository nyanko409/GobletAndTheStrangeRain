using UnityEngine;

public class DropletSpawner : MonoBehaviour
{
    public GameObject prefab;                   // the prefab to spawn
    public float dropletSpeed = 1F;             // speed of the droplet

    [ColorUsage(false, true)]
    public Color dropletColor = Color.blue;     // color of the droplet including hdr

    [Space]
    public Vector3 direction = Vector3.down;    // the direction the droplet is falling
    public float spawnInterval = 2F;            // spawn interval in seconds
    public float rippleSpreadSpeed = 0.2F;      // spread speed of the droplet


    float timeTillNextSpawn = 0;                // counter for next spawn


    void Update()
    {
        timeTillNextSpawn += Time.deltaTime;
        if(timeTillNextSpawn >= spawnInterval)
        {
            timeTillNextSpawn -= spawnInterval;

            // create prefab
            var go = Instantiate(prefab, transform.position, transform.rotation);

            // pass the values to the prefab
            var droplet = go.AddComponent<Droplet>();
            droplet.SetSpeed(dropletSpeed);
            droplet.SetDirection(direction);

            var provider = go.GetComponent<RippleEffectProvider>();
            provider.SetDirection(direction);
            provider.SetColor(dropletColor);
            provider.SetRippleSpreadSpeed(rippleSpreadSpeed);
        }
    }
}
