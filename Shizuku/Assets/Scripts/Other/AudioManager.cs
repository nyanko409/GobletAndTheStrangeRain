using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum AudioType
    {
        SE_Droplet
    }

    [System.Serializable]
    public struct AudioData
    {
        public AudioClip clip;
        public AudioType type;
        public float volume;

        internal AudioSource source;

        public AudioData(AudioClip clip, AudioType type, float volume, AudioSource source) : this()
        {
            this.clip = clip;
            this.type = type;
            this.volume = volume;
            this.source = source;
        }
    }


    public List<AudioData> bgm, se;

    private GameSettings settings;


    public AudioSource GetAudioSourceByType(AudioType type)
    {
        // search for audio type
        var source = bgm.Find(data => data.type == type).source;
        if (source) return source;

        source = se.Find(data => data.type == type).source;
        if (source) return source;

        // type not found
        return null;
    }

    public void UpdateVolumeFromSettings()
    {
        foreach (var audio in bgm)
            audio.source.volume = settings.masterVolume * settings.bgmVolume * audio.volume;

        foreach (var audio in se)
            audio.source.volume = settings.masterVolume * settings.seVolume * audio.volume;
    }


    private void Start()
    {
        // get game settings for volume
        settings = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Settings>().settings;

        // initialize audio sources for bgm and soundeffects
        for(int i = 0; i < bgm.Count; ++i)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = bgm[i].clip;

            bgm[i] = new AudioData(bgm[i].clip, bgm[i].type, bgm[i].volume, source);
        }

        for (int i = 0; i < se.Count; ++i)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = se[i].clip;

            se[i] = new AudioData(se[i].clip, se[i].type, se[i].volume, source);
        }
    }
}
