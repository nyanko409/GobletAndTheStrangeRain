using UnityEngine;
using UnityEngine.UI;

public class SkillImageUI : MonoBehaviour
{
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;
    public GameObject Image6;
    public GameObject Image7;
    public GameObject Image8;

    public DropDroplet data;
    int count=1;
    float woldtime;
    float time;
  
    private void ImageCK(bool a,bool b,bool c, bool d,bool e,bool f,bool g,bool h)
    {
        Image1.SetActive(a);
        Image2.SetActive(b);
        Image3.SetActive(c);
        Image4.SetActive(d);
        Image5.SetActive(e);
        Image6.SetActive(f);
        Image7.SetActive(g);
        Image8.SetActive(h);
    }
    void Start()
    {
       
       // ImageCK(true,false,false,false,false,false);

    }

   
    void Update()
    {
        Debug.Log(count); 
        woldtime += Time.deltaTime;
        time += Time.deltaTime;
        if(woldtime>=0.01f)
        {
            if (data.CanDrop())
            {
                if (count == 12)
                {
                    time = 0;
                    count = 1;
                }
                if (time >= 1f)
                {
                    count += 1;
                    time = 0;
                }
                if (count == 9)
                {
                    
                    count = 1;
                }
               
            }
            else
            {
                count = 12;
                
            }
            //Last
            woldtime = 0;
        }

        //Image
        switch(count)
        {
            case 1:
                ImageCK(true, false, false, false, false, false, false, false);
                break;
            case 2:
                ImageCK(false, true, false, false, false, false, false, false);
                break;
            case 3:
                ImageCK(false, false, true, false, false, false, false, false);
                break;
            case 4:
                ImageCK(false, false, false, false, false, false, false, false);
                break;
            case 5:
                ImageCK(false, false, false, false, true, false, false, false);
                break;
            case 6:
                ImageCK(false, false, false, false, false, true, false, false);
                break;
            case 7:
                ImageCK(false, false, false, false, false, false, true, false);
                break;
            case 8:
                ImageCK(false, false, false, false, false, false, false, false);
                break;

            case 12:
                ImageCK(false, false, false, false, false, false, false, false);
                break;
            default:

                Debug.Log("Not Image");
                break;
        }
    }
}
