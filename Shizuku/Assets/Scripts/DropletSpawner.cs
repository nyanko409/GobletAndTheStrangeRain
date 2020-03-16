using UnityEngine;

public class DropletSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float dropletSpeed = 1F;
    public Color dropletColor = Color.blue;
    [Space]
    public Vector3 direction = Vector3.down;
    public float spawnInterval = 2F;
    public float rippleSpreadSpeed = 0.2F;

    float timeTillNextSpawn = 0;


    void Update()
    {
        timeTillNextSpawn += Time.deltaTime;
        if(timeTillNextSpawn >= spawnInterval)
        {
            timeTillNextSpawn -= spawnInterval;
            var go = Instantiate(prefab, transform.position, transform.rotation);

            go.GetComponent<Droplet>().SetSpeed(dropletSpeed);
            go.GetComponent<Droplet>().SetDirection(direction);
            go.GetComponent<RippleEffectProvider>().SetDirection(direction);
            go.GetComponent<RippleEffectProvider>().SetColor(dropletColor);
            go.GetComponent<RippleEffectProvider>().SetRippleSpreadSpeed(rippleSpreadSpeed);
        }
    }
}
