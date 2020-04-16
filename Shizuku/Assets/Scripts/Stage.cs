using UnityEngine;
using UnityEngine.SceneManagement;


public class Stage : MonoBehaviour
{
    public string scene;
    public bool isLocked;
    public Sprite spriteLocked;
    public Color lockedColor;
    public Sprite spriteOutline;
    public Color outlineColor;

    SpriteRenderer rend;



    private void Start()
    {

        rend = GetComponent<SpriteRenderer>();

        if(isLocked)
        {
            Lock();
        }
        else
        {
            Unlock();
        }
    }

    private void Unlock()
    {
        rend.sprite = spriteOutline;
        rend.color = outlineColor;
        rend.enabled = false;
        isLocked = false;
    }

    private void Lock()
    {
        rend.sprite = spriteLocked;
        rend.color = lockedColor;
        rend.enabled = true;
        isLocked = true;
    }

    private void OnMouseEnter()
    {
        if (!isLocked)
            rend.enabled = true;
    }

    private void OnMouseExit()
    {
        if (!isLocked)
            rend.enabled = false;
    }

    private void OnMouseUp()
    {
        SceneManager.LoadScene(scene);
    }
}
