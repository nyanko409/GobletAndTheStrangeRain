using UnityEngine;

public class Droplet : MonoBehaviour
{
    public Vector3 Direction { private get; set; }      // the direction the droplet is falling
    public float Speed { private get; set; }            // the speed of the droplet

    private AudioSource dropletSound;


    void Start()
    {
        dropletSound = GameObject.FindWithTag("AudioManager").
            GetComponent<AudioManager>().GetAudioSourceByType(AudioManager.AudioType.SE_Droplet);

        Destroy(gameObject, 10F);
    }

    void Update()
    {
        // apply gravity in direction by speed
        transform.position += Direction * Time.deltaTime * Speed;
    }

    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(dropletSound.clip, transform.position, dropletSound.volume);
        print(dropletSound.volume);
    }
}
