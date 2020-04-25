using UnityEngine;

public class DropletSpawner : MonoBehaviour
{
    public GameObject prefab;                 // the prefab to spawn
    public float dropletSpeed = 1F;           // speed of the droplet
    [ColorUsage(false, true)]
    public Color dropletColor = Color.blue;   // color of the droplet including hdr
    [Space]
    public float spawnInterval = 2F;          // spawn interval in seconds
    public float startDelay = 0F;             // delay the first spawn
    public bool spawnImmediate = false;     
    public float rippleSpreadSpeed = 0.2F;    // spread speed of the droplet

    float timeTillNextSpawn = 0;              // counter for next spawn
    bool spawnStarted;


    private void Start()
    {
        if (spawnImmediate)
            timeTillNextSpawn = spawnInterval;
    }

    private void Update()
    {
        timeTillNextSpawn += Time.deltaTime;

        if(!spawnStarted && timeTillNextSpawn >= startDelay)
        {
            timeTillNextSpawn -= startDelay;
            spawnStarted = true;
        }

        if(timeTillNextSpawn >= spawnInterval)
        {
            timeTillNextSpawn -= spawnInterval;
            SpawnDroplet();
        }
    }

    private void SpawnDroplet()
    {
        // create prefab
        var go = Instantiate(prefab, transform.position, transform.rotation);

        // pass the values to the prefab
        var droplet = go.GetComponent<Droplet>();
        droplet.Speed = dropletSpeed;
        droplet.Direction = -transform.up;

        var provider = go.GetComponent<RippleEffectProvider>();
        provider.RippleColor = dropletColor;
        provider.RippleSpreadSpeed = rippleSpreadSpeed;

        go.GetComponent<Renderer>().material.SetColor("_BaseColor", dropletColor);
    }
}
