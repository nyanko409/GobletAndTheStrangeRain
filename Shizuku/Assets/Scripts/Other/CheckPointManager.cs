using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckPointManager : Singleton<CheckPointManager>
{
    private Vector3 startPoint;
    private Vector3 curSavePoint;
    private int sceneIndex;
    private bool init = false;


    public void SetSavePoint(Vector3 savePoint)
    {
        curSavePoint = savePoint;
    }

    public Vector3 GetSavePoint()
    {
        return curSavePoint;
    }

    public void ResetSavePoint()
    {
        curSavePoint = startPoint;
    }


    protected override void Awake()
    {
        base.Awake();
        if (isDestroyed || init) return;

        init = true;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        curSavePoint = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        startPoint = curSavePoint;
    }

    private void OnLevelWasLoaded(int level)
    {
        base.Awake();
        if (isDestroyed) return;

        if(sceneIndex != SceneManager.GetActiveScene().buildIndex &&
            SceneManager.GetActiveScene().name != "LoadingScreen")
        {
            Destroy(gameObject);
            return;
        }

        GameObject go = GameObject.FindWithTag("Player");
        if(go)
            go.transform.position = curSavePoint;
    }

    private void OnDestroy()
    {
        DeleteInstance();
    }
}
