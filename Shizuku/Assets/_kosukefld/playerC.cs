using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class playerC : MonoBehaviour
{

    //axes
    public Text axis1Value;
    public Text axis2Value;
    public Text axis3Value;
    public Text axis4Value;
    public Text axis5Value;
    public Text axis6Value;
    public Text axis7Value;
    public Text axis8Value;
    public Text axis9Value;
    public Text axis10Value;
    public Text axis11Value;
    public Text axis12Value;
    public Text axis13Value;
    public Text axis14Value;
    public Text axis15Value;
    public Text axis16Value;
    public Text axis17Value;
    public Text axis18Value;
    public Text axis19Value;
    public Text axis20Value;
    public Text axis21Value;
    public Text axis22Value;
    public Text axis23Value;
    public Text axis24Value; 
    public Text axis25Value;
    public Text axis26Value;
    public Text axis27Value;
    public Text axis28Value;

    //buttons
    public Text button0Value;
    public Text button1Value;
    public Text button2Value;
    public Text button3Value;
    public Text button4Value;
    public Text button5Value;
    public Text button6Value;
    public Text button7Value;
    public Text button8Value;
    public Text button9Value;
    public Text button10Value;
    public Text button11Value;
    public Text button12Value;
    public Text button13Value;
    public Text button14Value;
    public Text button15Value;
    public Text button16Value;
    public Text button17Value;
    public Text button18Value;
    public Text button19Value;

    // Droplet prefab
    public GameObject Droplet;

    // DropletAppearance
    public Transform mainchara;


    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        //light
        if (Input.GetAxis("Axis 1") > 0f|| Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(0.03f, 0, 0);


        }
        ///left
        else if (Input.GetAxis("Axis 1") < 0f || Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(-0.03f, 0, 0);
        }
        //down
        if (Input.GetAxis("Axis 2") > 0f || Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(0, 0, -0.03f);


        }
        //up
        if (Input.GetAxis("Axis 2") < 0f || Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Translate(0, 0, 0.03f);


        }

        //jump
        if (Input.GetKeyDown(KeyCode.JoystickButton0) == true || Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.transform.Translate(0, 1.0f, 0);
        }


        ////mizukobosi
        //if (Input.GetAxis("Axis 10") > 0f || Input.GetKeyDown(KeyCode.V))
        //{
        //    Debug.Log("Ripple");

        //    // Droplet
        //    GameObject Droplets = Instantiate(Droplet) as GameObject;

        //    Vector3 force;

        //    // Droplet Adjustment
        //    Droplets.transform.position = mainchara.position;

        //}
    }

}
