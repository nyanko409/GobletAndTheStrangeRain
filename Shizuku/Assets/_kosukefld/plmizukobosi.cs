using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class plmizukobosi : MonoBehaviour
{
    public Text axis10Value;

    // Droplet prefab
    public GameObject Droplet;

    // DropletAppearance
    public Transform mainchara;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mizukobosi
        if (Input.GetAxis("Axis 10") > 0f || Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("Ripple");

            // Droplet
            GameObject Droplets = Instantiate(Droplet) as GameObject;

            Vector3 force;

            // Droplet Adjustment
            Droplets.transform.position = mainchara.position;

        }
    }
}
