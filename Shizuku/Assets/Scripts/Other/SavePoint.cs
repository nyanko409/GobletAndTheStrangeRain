using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private SavePointManager manager;
    private bool triggered;


    private void Start()
    {
        manager = GameObject.FindWithTag("SavePointManager").GetComponent<SavePointManager>();
        triggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered)
            return;

        manager.SetSavePoint(transform.position);
        triggered = true;
    }
}
