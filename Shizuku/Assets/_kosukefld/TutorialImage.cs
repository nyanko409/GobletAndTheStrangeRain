using UnityEngine;
using UnityEngine.UI;

public class TutorialImage : MonoBehaviour
{
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;
    public GameObject Image6;
    public GameObject Image7;

    int count=1;
    bool STCK = false;

    bool upPressed;
    bool downPressed;
    private GameInput actions;

    private void ImageCK(bool a, bool b, bool c, bool d, bool e, bool f,bool g)
    {
        Image1.SetActive(a);
        Image2.SetActive(b);
        Image3.SetActive(c);
        Image4.SetActive(d);
        Image5.SetActive(e);
        Image6.SetActive(f);
        Image7.SetActive(g);
    }
    private void Awake()
    {
        actions = new GameInput();

        actions.TutorialMenu.NextUI.started+= context => { upPressed = true; };
        actions.TutorialMenu.NextUI.canceled += context => { upPressed = false; };

        actions.TutorialMenu.BackUI.started += context => { downPressed= true; };
        actions.TutorialMenu.BackUI.canceled += context => { downPressed = false; };
    }

        
        void Start()
    {
        Time.timeScale = 0;
        ImageCK(true,false,false,false,false,false,false);
    }

  
    void Update()
    {
        Debug.Log(Time.deltaTime);
       
        if(upPressed)
        {
            
            upPressed = false;
            count += 1;
            Debug.Log("check");
        }
        if(count>=8)
        {
            Time.timeScale = 1;
        }
        if(downPressed)
        {
            downPressed = false;
            count -= 1;
            Debug.Log("Bcheck");
        }
       
        switch(count)
        {
            case 1:
                ImageCK(true, false, false, false, false, false, false);
                break;
            case 2:
                ImageCK(false, true, false, false, false, false, false);
                break;
            case 3:
                ImageCK(false, false, true, false, false, false, false);
                break;
            case 4:
                ImageCK(false, false, false, true, false, false, false);
                break;
            case 5:
                ImageCK(false, false, false, false, true, false, false);
                break;
            case 6:
                ImageCK(false, false, false, false, false, true, false);
                break;
            case 7:
                ImageCK(false, false, false, false, false, false, true);
                break;
            case 8:
                ImageCK(false, false, false, false, false, false, false);
                break;
            default:
                break;
        }
    }
    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
