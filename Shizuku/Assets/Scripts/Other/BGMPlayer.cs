using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public AudioManager.AudioType bgm;

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

        bgmSource = manager.GetAudioSourceByType(bgm);
        bgmSource.Play();

        ambientSource = manager.GetAudioSourceByType(AudioManager.AudioType.BGM_Rain);
        ambientSource.Play();
    }

    private void OnDestroy()
    {
        StopAllBgm();
    }
}
