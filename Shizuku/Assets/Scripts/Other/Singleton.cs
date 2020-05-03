using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static MonoBehaviour instance;


    private void Awake()
    {
        // allow only one instance of this object
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }
}
