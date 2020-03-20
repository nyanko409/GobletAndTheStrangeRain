using UnityEngine;

public class DropletSpawner : MonoBehaviour
{
    public GameObject prefab;                   // the prefab to spawn
    public float dropletSpeed = 1F;             // speed of the droplet

    [ColorUsage(false, true)]
    public Color dropletColor = Color.blue;     // color of the droplet including hdr

    [Space]
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
            droplet.SetDirection(-transform.up);

            var provider = go.GetComponent<RippleEffectProvider>();
            provider.SetDirection(-transform.up);
            provider.SetColor(dropletColor);
            provider.SetRippleSpreadSpeed(rippleSpreadSpeed);
        }
    }
}
