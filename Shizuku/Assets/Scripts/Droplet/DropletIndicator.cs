using UnityEngine;

public class DropletIndicator : MonoBehaviour
{
    public GameObject prefab;       // sprite to project
    public float finalScale = 0;    // the final scale when droplet collides with the floor

    GameObject indicator;           // reference to the instantiated prefab
    float startSqrMag;              // the square length of the distance vector
    Vector3 startScale;


    void Start()
    {
        ProjectIndicator();
    }

    void Update()
    {
        if(indicator)
        {
            // get the diff length ratio
            float sqrMag = (indicator.transform.position - transform.position).sqrMagnitude;
            float magRatio = sqrMag / startSqrMag;

            // multiply it with the scale and add offset
            indicator.transform.localScale = startScale * magRatio;
            indicator.transform.localScale += new Vector3(finalScale, finalScale, 0);
        }
    }

    private void ProjectIndicator()
    {
        // get the position to spawn the prefab
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.up, out hit, 1000, LayerMask.GetMask("Room")))
        {
            // set the parent and offset the position by a tiny value
            indicator = Instantiate(prefab);
            indicator.transform.position = hit.point + hit.normal * 0.01F;

            // rotate the projection to look at hit normal
            indicator.transform.rotation = Quaternion.LookRotation(hit.normal);

            // get the start square magnitude (faster than getting the magnitude)
            startSqrMag = (indicator.transform.position - transform.position).sqrMagnitude;
            startScale = indicator.transform.localScale;

            // add offset to scale
            indicator.transform.localScale += new Vector3(finalScale, finalScale, 0);
        }
    }

    private void OnDestroy()
    {
        Destroy(indicator);
    }
}
