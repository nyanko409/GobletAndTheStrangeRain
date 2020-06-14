using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    protected bool isDestroyed = false;
    private static T _instance;

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this as T;
        }
        else
        {
            if (this != _instance)
            {
                Destroy(gameObject);
                isDestroyed = true;
            }
        }
    }

    protected void DeleteInstance()
    {
        if(this == _instance)
            _instance = null;
    }
}
