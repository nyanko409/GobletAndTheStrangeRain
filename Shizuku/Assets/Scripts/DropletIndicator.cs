using UnityEngine;

public class DropletIndicator : MonoBehaviour
{
    public GameObject prefab;   // sprite to project

    GameObject indicator;       // reference to the instantiated prefab
 

    void Start()
    {
        ProjectIndicator();
    }

    void Update()
    {
        if(transform.hasChanged)
        {
            transform.hasChanged = false;

            // project the prefab again on the new location
            Destroy(indicator);
            ProjectIndicator();
        }
    }

    void ProjectIndicator()
    {
        // get the position to spawn the prefab
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.up, out hit, 100))
        {
            // set the parent and offset the position by a tiny value
            indicator = Instantiate(prefab, transform);
            indicator.transform.position = hit.point + hit.normal * 0.01F;

            // rotate the projection to look at hit normal
            indicator.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
    }
}
