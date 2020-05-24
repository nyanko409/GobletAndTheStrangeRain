using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{
    public GameObject aura;
    public float auraTransitionSpeed = 1;

    private CheckPointManager manager;
    private bool triggered;


    private void Start()
    {
        manager = GameObject.FindWithTag("CheckPointManager").GetComponent<CheckPointManager>();

        triggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered)
            return;

        manager.SetSavePoint(transform.position);
        StartCoroutine("PlayAnimation");
        triggered = true;
    }

    private IEnumerator PlayAnimation()
    {
        float transitionValue = 0;
        Material mat = aura.GetComponent<Renderer>().material;

        while (transitionValue < 1.0F)
        {
            mat.SetFloat("transitionValue", transitionValue);
            transitionValue += auraTransitionSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
