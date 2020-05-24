using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMPlayer : MonoBehaviour
{
    private AudioManager manager;
    private AudioSource bgmSource;
    private AudioSource ambientSource;


    private void Start()
    {
        manager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();

        ambientSource = manager.GetAudioSourceByType(AudioManager.AudioType.BGM_Rain);
        ambientSource.Play();
    }
}
