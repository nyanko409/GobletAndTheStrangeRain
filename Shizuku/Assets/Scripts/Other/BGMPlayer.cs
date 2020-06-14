using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public AudioManager.AudioType bgm;
    public AudioManager.AudioType ambient;
    public bool playBGM, playAmbient;

    private AudioManager manager;
    private AudioSource bgmSource;
    private AudioSource ambientSource;


    public void StopAllBgm()
    {
        if(bgmSource)
            bgmSource.Stop();

        if(ambientSource)
            ambientSource.Stop();
    }

    private void Start()
    {
        manager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();

        if (playBGM)
        {
            bgmSource = manager.GetAudioSourceByType(bgm);
            bgmSource.Play();
        }

        if(playAmbient)
        {
            ambientSource = manager.GetAudioSourceByType(ambient);
            ambientSource.Play();
        }
    }

    private void OnDestroy()
    {
        StopAllBgm();
    }
}
