using UnityEngine;

public class DropletPredictor : MonoBehaviour
{
    public GameObject prefab;   // sprite to project

    GameObject projector;
    Quaternion oldRotation;     // old rotation value to check if rotation has changed
 

    void Start()
    {
        oldRotation = transform.rotation;
        ProjectPredictor();
    }

    void Update()
    {
        if(oldRotation != transform.rotation)
        {
            // project the prefab again on the new location
            oldRotation = transform.rotation;

            Destroy(projector);
            ProjectPredictor();
        }
    }

    void ProjectPredictor()
    {
        // get the position to spawn the prefab
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.up, out hit, 100))
        {
            // set the parent and offset the position by a tiny value
            projector = Instantiate(prefab, transform);
            projector.transform.position = hit.point + hit.normal * 0.01F;

            // rotate the projection to look at hit normal
            projector.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
    }
}
